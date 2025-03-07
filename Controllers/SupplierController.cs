using Microsoft.AspNetCore.Mvc;
using UITraining.Interfaces;
using UITraining.Models.DB;
using UITraining.Models.DTO;

namespace UITraining.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplier _supplier;

        public SupplierController(ISupplier supplier)
        {
            _supplier = supplier;
        }
        public IActionResult Index()
        {
            var supplier = _supplier.GetAllSupplier();
            return View(supplier);

           
        }


        public  IActionResult Edit(int Id)
        {
            var supplier = _supplier.GetSupplierById(Id);
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(SupplierDTO suplier)
        {
            if (suplier.Id == 0)
            {
                var data = _supplier.AddSupplier(suplier);
                if (data)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                var data = _supplier.EditSupplier(suplier);
                if (data)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var delsuplier = _supplier.DeleteSupplier(Id);
            if (delsuplier)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("Delete not succes");
        }




    }
}
