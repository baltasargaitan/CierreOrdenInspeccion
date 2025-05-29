using System;
using System.Collections.Generic;
using System.Linq;

namespace CierreOrdenInspeccion.Models
{
    public class GestorCierreInspeccion
    {
        public string ObservacionDeCierre { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public string MailResponsableCierre { get; set; }
        public List<string> CorreosEmpleados { get; set; } = new List<string>();

        // Obtiene el empleado RI desde la sesión (a través del usuario)
        public Empleado BuscarRILogueado(Sesion sesion)
        {
            return sesion.ObtenerUsuario().GetRILogueado();
        }

        // Filtra solo las órdenes del empleado
        public List<OrdenInspeccion> BuscarOrdenes(List<OrdenInspeccion> todas, int empleadoId)
        {
            return todas.Where(o => o.EsDeEmpleado(empleadoId)).ToList();
        }

        // Ordena cronológicamente las órdenes
        public List<OrdenInspeccion> OrdenarOrdenes(List<OrdenInspeccion> ordenes)
        {
            return ordenes.OrderBy(o => o.FechaHoraInicio).ToList();
        }

        public List<OrdenInspeccion> OpcionCerrarOrdenDeInspeccion(Sesion sesion, List<OrdenInspeccion> todas)
        {
            var empleado = BuscarRILogueado(sesion);
            var ordenesEmpleado = BuscarOrdenes(todas, empleado.Id);
            return OrdenarOrdenes(ordenesEmpleado);
        }


        public void TomarSeleccionOrden(OrdenInspeccion ordenSeleccionada)
        {
            // Puede usarse para almacenar en variable interna si fuera necesario
        }

        public void TomarObservaciones(string observacion)
        {
            this.ObservacionDeCierre = observacion;
        }

        public List<MotivoTipo> BuscarMotivosFueraDeServicio(List<MotivoTipo> todos)
        {
            return todos; 
        }

        public void TomarMotivoFueraDeServicio(MotivoTipo tipo, string comentario, out MotivoFueraServicio motivo)
        {
            motivo = new MotivoFueraServicio
            {
                Tipo = tipo
            };
            motivo.SetComentario(comentario);
        }

        public bool ValidarDatosMinimosReqParaCierre(OrdenInspeccion orden)
        {
            return orden.EstaCompletamenteRealizado();
        }

        public Estado BuscarEstadoCerradoParaOrdenInspeccion(List<Estado> estados)
        {
            return estados.FirstOrDefault(e => e.EsAmbitoOrdenInspeccion() && e.EsCerrada());
        }

        public Estado BuscarEstadoSismografoFueraDeServicio(List<Estado> estados)
        {
            return estados.FirstOrDefault(e => e.EsAmbitoSismografo() && e.EsFueraDeServicio());
        }

        public DateTime GetFechaHoraActual()
        {
            return DateTime.Now;
        }

        // Esta es la forma correcta de cerrar la orden, respetando los métodos del modelo
        public void CerrarOrdenInspeccion(OrdenInspeccion orden, Estado estadoCerrado)
        {
            orden.SetEstado(estadoCerrado);
            orden.SetFechaHoraCierre(GetFechaHoraActual());
        }

        public void EnviarSismografoParaReparacion(Sismografo sismografo, Estado estadoFuera)
        {
            sismografo.PonerSismografoFueraDeServicio(estadoFuera);
            sismografo.EnviarAReparar();
        }

        public List<string> ObtenerMailResponsableDeReparacion(List<Empleado> empleados)
        {
            return empleados
                .Where(e => e.EsResponsableDeReparacion())
                .Select(e => e.ObtenerMail())
                .ToList();
        }

        public void PublicarEnMonitores(string mensaje)
        {
            Console.WriteLine($"[Monitor] {mensaje}");
        }

        public void EnviarNotificacionesPorMail(List<string> correos, string asunto, string cuerpo)
        {
            foreach (var correo in correos)
            {
                Console.WriteLine($"📧 Enviando a: {correo} - Asunto: {asunto}");
            }
        }

        public void FinCU()
        {
            ObservacionDeCierre = null;
            CorreosEmpleados.Clear();
            // Loguear cierre, liberar recursos, etc.
        }
    }
}
