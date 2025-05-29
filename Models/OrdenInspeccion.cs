using System;

namespace CierreOrdenInspeccion.Models
{
    public class OrdenInspeccion
    {
        public int Id { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime? FechaHoraFinalizacion { get; set; }
        public DateTime? FechaHoraCierre { get; set; }
        public string ObservacionCierre { get; set; }
        public string NroOrden { get; set; }

        public int EstadoId { get; set; }
        public Estado EstadoActual { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public int SismografoId { get; set; }
        public Sismografo Sismografo { get; set; }

        public bool EsDeEmpleado(int empleadoId) => EmpleadoId == empleadoId;
        public bool EstaCompletamenteRealizado() => FechaHoraFinalizacion.HasValue;

        public void MostrarDatosOrden() { /* puede ser usado para armar DTOs */ }
        public string GetNroOrden() => NroOrden;
        public DateTime? GetFechaFinalizacion() => FechaHoraFinalizacion;
        public void SetFechaHoraCierre(DateTime fecha) => FechaHoraCierre = fecha;
        public void SetEstado(Estado nuevoEstado) => EstadoActual = nuevoEstado;
        public void Cerrar() => FechaHoraCierre = DateTime.Now;
        public void EnviarSismografoParaReparacion() => Sismografo.EnviarAReparar();
    }

}
