namespace MiApi.Model
{
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Proyecto> Proyectos { get; } = new List<Proyecto>();
    }
}
