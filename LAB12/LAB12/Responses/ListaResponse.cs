namespace LAB12.Responses
{
    public class ListaResponse<T>
    {
        public List<T> Datos { get; set; }

        public int Total { get; set; }
    }
}