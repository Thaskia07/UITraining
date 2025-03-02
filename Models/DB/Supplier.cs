namespace UITraining.Models.DB
{
    public class supplier
    {

        public int Id { get; set; }
        public string SupplierName { get; set; }

        public string SupplierAddress { get; set; }

        public ICollection<Produk> Produk { get; set; } = new List<Produk>();


    }
}
