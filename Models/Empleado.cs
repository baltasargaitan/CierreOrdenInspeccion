using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public bool EsResponsableDeReparacion() => Rol?.Nombre == "ResponsableDeReparacion";
        public string ObtenerMail() => Mail;
    }
}
