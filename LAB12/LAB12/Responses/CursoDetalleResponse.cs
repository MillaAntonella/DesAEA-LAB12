namespace LAB12.Responses
{
    public class CursoDetalleResponse
    {
        public int IdCurso { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int DuracionHoras { get; set; }

        public string NombreInstructor { get; set; }
    }
}