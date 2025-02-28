using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;
using UITraining.Models.DB;
using UITraining.Services;

namespace UITraining.Controllers
{
    public class ProdukController : Controller
    {
        private readonly IProduct _interface;

        public ProdukController(IProduct interfaces)
        {
            _interface = interfaces;
        }

        public IActionResult Index()
        {
            var products = _interface.GetAllproduct();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            var product = _interface.GetProdukById(id);
            if (product == null || product.ProductStatus == ProdukStatus.deleted || product.IsDeleted == true)
            {
                return NotFound(); 
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Produk produk)
        {
            var editProduct = _interface.EditProduct(produk);
            if (editProduct)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(produk);
        }

        public IActionResult Delete(int id)
        {
            var result = _interface.DeleteProduct(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
