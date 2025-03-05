namespace ZeroTwo.Models
{
    public class ProductoModel
    {
        public int? CodigoProducto { get; set; }

        public string NombreProducto { get; set; } = null!;

        public decimal PrecioCosto { get; set; }

        public decimal PrecioVenta { get; set; }

        public int ExistenciaProducto { get; set; }

        public int CodigoMarca { get; set; }

        public string? nombreMarca { get; set; }
    }
}
