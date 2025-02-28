using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.DB;

namespace UITraining.Services
{
    public class ProdukServices : IProduct
    {
        private readonly ApplicationContext _context;

        public ProdukServices(ApplicationContext context)
        {
            _context = context;
        }

        public List<Produk> GetAllproduct()
        {
            var product = _context.produks.Where(x => x.ProductStatus != ProdukStatus.deleted).Select(x => new Produk
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ProductStatus = x.ProductStatus,


            }).ToList();
            return product;
        }
        public Produk GetProdukById(int id)
        {
            var product = _context.produks
                .Where(x => x.Id == id && x.ProductStatus != ProdukStatus.deleted).FirstOrDefault();

            if (product == null)
            {
                return new Produk();
            }

            return product;
        }
        public bool EditProduct(Produk produk)
        {
            var data = _context.produks.FirstOrDefault(x=>x.Id == produk.Id);
            if(data == null)
            {
                return false;
            }

            data.Name = produk.Name;
            data.Description = produk.Description;
            data.Stock = produk.Stock;
            data.Price = produk.Price;
            data.ProductStatus = produk.ProductStatus;

            _context.produks.Update(data);
            _context.SaveChanges();
            
            return true;
        }


        public bool DeleteProduct(int id)
        {
            var data = _context.produks.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return false;
            }

            // Ubah status menjadi deleted (soft delete)
            data.ProductStatus = ProdukStatus.deleted;
            _context.produks.Update(data);
            _context.SaveChanges();

            return true;
        }


    }
}
