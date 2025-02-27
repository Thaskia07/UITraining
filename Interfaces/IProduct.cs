using UITraining.Models.DB;

namespace UITraining.Interfaces
{
    public interface IProduct
    {
        public List<Produk> GetAllproduct();


        public Produk GetProdukById(int id);

        public bool EditProduct(Produk produk);

        public bool DeleteProduct(int id);

    }
}
