using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CierreOrdenInspeccion.Models;

namespace CierreOrdenInspeccion.Controllers
{
    public class CierreInspeccionController : Controller
    {
        // Simulador de base de datos (más adelante usaremos EF)
        private static List<OrdenInspeccion> ordenes = new List<OrdenInspeccion>();
        private static List<Estado> estados = new List<Estado>();
        private static List<MotivoTipo> motivos = new List<MotivoTipo>();
        private static List<Empleado> empleados = new List<Empleado>();

        private GestorCierreInspeccion gestor = new GestorCierreInspeccion();

        private AppDbContext db = new AppDbContext();

        public ActionResult OpcionCerrarOrden()
        {
            var sesion = CrearSesionSimulada();
            var ordenesOrdenadas = gestor.OpcionCerrarOrdenDeInspeccion(sesion, db.Ordenes.Include("Empleado").ToList());

            ViewBag.Empleado = gestor.BuscarRILogueado(sesion).Nombre;
            return View("SeleccionarOrden", ordenesOrdenadas);
        }



        [HttpPost]
        public ActionResult TomarSeleccionOrden(int id)
        {
            var orden = ordenes.FirstOrDefault(o => o.Id == id);
            gestor.TomarSeleccionOrden(orden);
            return View("IngresarObservacion", orden);
        }

        [HttpPost]
        public ActionResult TomarObservacion(int ordenId, string observacion)
        {
            gestor.TomarObservaciones(observacion);
            var motivosDisponibles = gestor.BuscarMotivosFueraDeServicio(motivos);
            ViewBag.OrdenId = ordenId;
            return View("SeleccionarMotivo", motivosDisponibles);
        }

        [HttpPost]
        public ActionResult ConfirmarMotivo(int ordenId, int motivoId, string comentario)
        {
            var motivoTipo = motivos.FirstOrDefault(m => m.Id == motivoId);
            gestor.TomarMotivoFueraDeServicio(motivoTipo, comentario, out MotivoFueraServicio motivo);
            var orden = ordenes.FirstOrDefault(o => o.Id == ordenId);

            var validacion = gestor.ValidarDatosMinimosReqParaCierre(orden);
            if (!validacion)
                return View("Error", model: "Orden incompleta");

            var estadoCerrado = gestor.BuscarEstadoCerradoParaOrdenInspeccion(estados);
            gestor.CerrarOrdenInspeccion(orden, estadoCerrado);

            var estadoFuera = gestor.BuscarEstadoSismografoFueraDeServicio(estados);
            gestor.EnviarSismografoParaReparacion(orden.Sismografo, estadoFuera);

            var mails = gestor.ObtenerMailResponsableDeReparacion(empleados);
            gestor.EnviarNotificacionesPorMail(mails, "Orden cerrada", "Se cerró la orden correctamente");

            gestor.FinCU();
            return View("Confirmacion", orden);
        }

        // Método auxiliar para testear sin BD
        private Sesion CrearSesionSimulada()
        {
            var empleado = new Empleado { Id = 1, Nombre = "Mario", Rol = new Rol { Nombre = "Tecnico" } };
            empleados.Add(empleado);

            var usuario = new Usuario { Id = 1, NombreUsuario = "mario", Empleado = empleado };
            var sesion = new Sesion { Id = 1, Usuario = usuario, FechaHoraDesde = DateTime.Now };
            return sesion;
        }
    }
}
