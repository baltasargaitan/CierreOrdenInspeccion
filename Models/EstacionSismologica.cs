using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class EstacionSismologica
    {
        public int Id { get; set; }
        public string CodigoEstacion { get; set; }
        public string Nombre { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string DocumentoCertificacionAdquirida { get; set; }
        public string NroCertificacionAdquisicion { get; set; }
        public DateTime? FechaSolicitudCertificacion { get; set; }

        public string GetCodigoEstacion() => CodigoEstacion;
        public string GetNombre() => Nombre;
        public int ObtenerIdSismografo() => Id; // según cómo se relacione con el sismógrafo
    }

}
