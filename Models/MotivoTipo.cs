using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class MotivoTipo
    {
        public int Id { get; set; }
        public string TipoMotivo { get; set; }
        public string Descripcion { get; set; }

        public string GetDescripcion() => Descripcion;
    }
}
