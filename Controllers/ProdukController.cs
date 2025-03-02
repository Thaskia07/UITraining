using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.DB;
using UITraining.Models.DTO;
using UITraining.Services;
using static UITraining.Models.GeneralStatus;


namespace UITraining.Controllers
{
    public class ProdukController : Controller
    {
        private readonly IProduct _interface;
        private readonly ISupplier _supplier;

        public ProdukController(IProduct interfaces, ISupplier supplier)
        {
            _interface = interfaces;
            _supplier = supplier;
        }

        public IActionResult Index()
        {
            var products = _interface.GetAllproduct();

            return View(products);
        }

        public IActionResult Edit(int id)
        {

            ViewBag.Supplier = _supplier.Suppliers();
            var product = _interface.GetProdukById(id);
            if (product == null || product.ProductStatus == GeneralStatusData.deleted || product.IsDeleted == true)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ProductDTO produk)
        {
            if (produk.Id == 0)
            {
                var addProduct = _interface.AddProduct(produk);
                if (addProduct)
                {
                    return RedirectToAction(nameof(Index));
                }

                //ProductDTO produk = produk;
                var editProduct = _interface.EditProduct(produk);
                if (editProduct)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
                return View();
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

