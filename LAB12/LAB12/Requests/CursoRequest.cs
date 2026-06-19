namespace LAB12.Requests
{
    public class CursoRequest
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int DuracionHoras { get; set; }

        public int IdInstructor { get; set; }
    }
}