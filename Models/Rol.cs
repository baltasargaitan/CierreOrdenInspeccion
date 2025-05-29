using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string GetNombre() => Nombre;
    }
}
