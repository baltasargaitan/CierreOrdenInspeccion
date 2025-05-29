using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace CierreOrdenInspeccion.Models
{
	public class CambioEstado
	{
		public int Id { get; set; }
		public DateTime FechaHoraInicio { get; set; }
		public DateTime? FechaHoraFin { get; set; }

		public int EstadoId { get; set; }
		public Estado Estado { get; set; }

		public bool EsEstadoActual()
		{
			return !FechaHoraFin.HasValue;
		}

		public void SetFechaHoraFin(DateTime fechaHoraFin)
		{
			FechaHoraFin = fechaHoraFin;
		}
	}
}
