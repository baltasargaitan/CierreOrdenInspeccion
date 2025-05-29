namespace CierreOrdenInspeccion.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ambito { get; set; } // "OrdenInspeccion" o "Sismografo"

        public bool EsAmbitoOrdenInspeccion() => Ambito == "OrdenInspeccion";
        public bool EsAmbitoSismografo() => Ambito == "Sismografo";
        public bool EsCerrada() => Nombre == "Cerrada";
        public bool EsFueraDeServicio() => Nombre == "FueraDeServicio";
    }
}
