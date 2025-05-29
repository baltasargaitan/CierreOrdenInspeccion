using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CierreOrdenInspeccion.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            // Estados
            var estadoPendiente = new Estado { Nombre = "PendienteDeRealización", Ambito = "OrdenInspeccion" };
            var estadoCerrada = new Estado { Nombre = "Cerrada", Ambito = "OrdenInspeccion" };
            var estadoFuera = new Estado { Nombre = "FueraDeServicio", Ambito = "Sismografo" };

            context.Estados.AddRange(new[] { estadoPendiente, estadoCerrada, estadoFuera });

            // Rol y Empleado
            var rol = new Rol { Nombre = "Tecnico" };
            var empleado = new Empleado { Id = 1, Nombre = "Mario", Rol = rol };
            context.Empleados.Add(empleado);

            // Sismógrafo
            var sismografo = new Sismografo { IdentificacionSismografo = "SISMO-001" };
            context.Sismografos.Add(sismografo);

            // Orden de inspección
            var orden = new OrdenInspeccion
            {
                Id = 1,
                NroOrden = "OI-0001",
                FechaHoraInicio = DateTime.Now.AddHours(-2),
                FechaHoraFinalizacion = DateTime.Now.AddHours(-1),
                Empleado = empleado,
                Sismografo = sismografo,
                EstadoActual = estadoPendiente
            };
            context.Ordenes.Add(orden);

            // Cambio de estado inicial (sin FechaHoraFin)
            var cambioEstado = new CambioEstado
            {
                Estado = estadoPendiente,
                FechaHoraInicio = orden.FechaHoraInicio,
                FechaHoraFin = null
            };
            context.CambioEstado.Add(cambioEstado);

            // MotivoTipo
            var motivo = new MotivoTipo { Descripcion = "Batería agotada" };
            context.Motivos.Add(motivo);

            context.SaveChanges();
        }
    }
}
