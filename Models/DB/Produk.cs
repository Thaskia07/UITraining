namespace UITraining.Models.DB
{
    public class Produk
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public ProdukStatus ProductStatus { get; set; }


    }

    public enum ProdukStatus{ 
        publishe,
        unpublished,
        deleted

    }
}
