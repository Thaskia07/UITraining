using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.DB;
using UITraining.Models.DTO;
using static UITraining.Models.GeneralStatus;

namespace UITraining.Services
{
    public class ProdukServices : IProduct
    {
        private readonly ApplicationContext _context;

        public ProdukServices(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductDTO> GetAllproduct()
        {
            var product = _context.produks
                .Include(y => y.Supplier)
                .Where(x => x.ProductStatus != GeneralStatusData.deleted)
                .Select(x => new ProductDTO
                { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                ProductStatus = x.ProductStatus,
                SupplierName = x.Supplier.SupplierName
            }).ToList();


            return product;
        }
        public Produk GetProdukById(int id)
        {
            var product = _context.produks
                .Where(x => x.Id == id && x.ProductStatus != GeneralStatusData.deleted).FirstOrDefault();

            if (product == null)
            {
                return new Produk();
            }

            return product;
        }
        public bool EditProduct(ProductDTO produk)
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



        public bool AddProduct(ProductDTO produk)
        {
            //    var datas = _context.produks.Select(x => new Produk
            //    {
            //        IdSupplier = produk.IdSupplier,
            //        Name = produk.Name,
            //        Description = produk.Description,
            //        Stock = produk.Stock,
            //        Price = produk.Price,
            //        ProductStatus = produk.ProductStatus,

            //    });
            //    _context.produks.Add(datas);
            //    _context.SaveChanges();


            var datas = new Produk();


            datas.IdSupplier = produk.IdSupplier;
            datas.Name = produk.Name;
            datas.Description = produk.Description;
            datas.Stock = produk.Stock;
            datas.Price = produk.Price;
            datas.ProductStatus = produk.ProductStatus;
            _context.produks.Add(datas);
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
            data.ProductStatus = GeneralStatusData.deleted;
            _context.produks.Update(data);
            _context.SaveChanges();

            return true;
        }


    }
}
