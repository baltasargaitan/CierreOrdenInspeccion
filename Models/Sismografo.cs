using System;

namespace CierreOrdenInspeccion.Models
{
    public class Sismografo
    {
        public int Id { get; set; }
        public string IdentificacionSismografo { get; set; }
        public string NroSerie { get; set; }
        public DateTime FechaAdquisicion { get; set; }

        public int EstacionId { get; set; }
        public EstacionSismologica Estacion { get; set; }

        public int EstadoId { get; set; }
        public Estado EstadoActual { get; set; }

        public string GetIdentificadorSismografo() => IdentificacionSismografo;
        public bool SosDeEstacionSismologica(int estacionId) => EstacionId == estacionId;
        public Estado ObtenerEstadoActual() => EstadoActual;

        public CambioEstado CrearCambioEstado(Estado nuevoEstado)
        {
            return new CambioEstado
            {
                Estado = nuevoEstado,
                FechaHoraInicio = DateTime.Now
            };
        }

        public void SetEstadoActual(Estado estado) => EstadoActual = estado;

        public void PonerSismografoFueraDeServicio(Estado estado) => EstadoActual = estado;

        public void EnviarAReparar()
        {
            // delega a lógica posterior de reparación
        }
    }

}
