using UITraining.Models.DB;
using UITraining.Models.DTO;

namespace UITraining.Interfaces
{
    public interface IProduct
    {
        public List<ProductDTO> GetAllproduct();


        public Produk GetProdukById(int id);

        public bool EditProduct(ProductDTO produk);

        public bool AddProduct(ProductDTO produk);

        public bool DeleteProduct(int id);

    }
}
