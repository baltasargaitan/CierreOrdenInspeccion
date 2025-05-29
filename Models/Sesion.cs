using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace CierreOrdenInspeccion.Models
{
    public class Sesion
    {
        public int Id { get; set; }
        public DateTime FechaHoraDesde { get; set; }
        public DateTime? FechaHoraHasta { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public Usuario ObtenerUsuario() => Usuario;
        public bool EsVigente() => !FechaHoraHasta.HasValue;
    }
}
