namespace MVCCORE_CRUD.Data.CreateModels
{
    public class ProductoModel
    {
        public int? codigo { get; set; }

        public string? nombre { get; set; }

        public decimal precioc { get; set; }

        public decimal preciov { get; set; }

        public int existencia { get; set; }

        public string? marca { get; set; }

        public int codigomodelo { get; set; }
        public int codigomarca { get; set; }
    }
}
