using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }

        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }

        public Empleado GetRILogueado()
        {
            return Empleado;
        }
    }
}
