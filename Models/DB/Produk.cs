using static UITraining.Models.GeneralStatus;

namespace UITraining.Models.DB
{
    public class Produk
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public GeneralStatusData ProductStatus { get; set; }

        public int IdSupplier {  get; set; }
        public supplier Supplier { get; set; }
        public bool IsDeleted { get; set; } = false; // Default false




    }


}
