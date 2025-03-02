using Microsoft.AspNetCore.Mvc.Rendering;
using UITraining.Models.DB;

namespace UITraining.Interfaces
{
    public interface ISupplier
    {

        //public List<Supplier> GetSupplier();
        public List<SelectListItem> Suppliers();

    }
}
