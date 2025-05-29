using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace CierreOrdenInspeccion.Models
{
    public class MotivoFueraServicio
    {
        public int Id { get; set; }
        public string Comentario { get; set; }

        public int MotivoTipoId { get; set; }
        public MotivoTipo Tipo { get; set; }

        public void SetComentario(string comentario) => Comentario = comentario;
    }
}
