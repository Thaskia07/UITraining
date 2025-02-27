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

            var products = _interface.GetProdukById(id);
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Produk produk)
        {
            var EditProduct = _interface.EditProduct(produk);
            if (EditProduct)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var delproduct = _interface.DeleteProduct(Id);
            if (delproduct)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Delete not succes");
        }
    }
}
