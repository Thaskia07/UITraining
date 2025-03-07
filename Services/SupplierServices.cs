using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UITraining.Interfaces;
using UITraining.Models;
using UITraining.Models.DB;
using static UITraining.Models.GeneralStatus;
using UITraining.Models.DTO;

namespace UITraining.Services
{
    public class SupplierServices : ISupplier
    {
        public readonly ApplicationContext _context;

        public SupplierServices(ApplicationContext context)
        {
            _context = context;
        }

        //public List<Supplier> GetSupplier()
        // {
        //     var datas = _context.Suppliers.ToList();
        //     return datas;
        // }

        public List<SelectListItem> Suppliers()
        {
            var datas = _context.Suppliers
                .Select(x => new SelectListItem
                {
                    Text = x.SupplierName,
                    Value = x.Id.ToString(),
                }).ToList();

            return datas;
        }
        public List<SupplierDTO> GetAllSupplier()
        {
            var supplier = _context.Suppliers
                //.Include(y => y.Supplier)
                .Where(x => x.SupplierStatus != GeneralStatusData.deleted)
                .Select(x => new SupplierDTO
                {
                    Id = x.Id,
                    SupplierName = x.SupplierName,
                    SupplierAddress = x.SupplierAddress,
                    SupplierStatus = x.SupplierStatus,
                }).ToList();


            return supplier;
        }


        public supplier GetSupplierById(int id)
        {
            var supplier = _context.Suppliers
                .Where(x => x.Id == id && x.SupplierStatus != GeneralStatusData.deleted).FirstOrDefault();

            if (supplier == null)
            {
                return new supplier();
            }

            return supplier;
        }
        public bool EditSupplier(SupplierDTO supplier)
        {
            var data = _context.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
            if (data == null)
            {
                return false;
            }

            data.SupplierName = supplier.SupplierName;
            data.SupplierAddress = supplier.SupplierAddress;
            data.SupplierStatus = supplier.SupplierStatus;

            _context.Suppliers.Update(data);
            _context.SaveChanges();

            return true;
        }



        public bool AddSupplier(SupplierDTO supplier)
        {
            //var datas = _context.Suppliers.Select(x => new supplier
            //{
            //    SupplierName = supplier.NameSupplier,
            //    SupplierAddress = supplier.SupplierAddress,
            //    SupplierStatus = supplier.SupplierStatus,

            //});

            var datas = new supplier();


            datas.SupplierName = supplier.SupplierName;
            datas.SupplierAddress = supplier.SupplierAddress;
            datas.SupplierStatus = supplier.SupplierStatus;

            _context.Suppliers.Add(datas);
            _context.SaveChanges();

            return true;
        }
        public bool DeleteSupplier(int id)
        {
            var data = _context.Suppliers.FirstOrDefault(x => x.Id == id);
            if (data == null)
            {
                return false;
            }

            // Ubah status menjadi deleted (soft delete)
            data.SupplierStatus = GeneralStatusData.deleted;
            _context.Suppliers.Update(data);
            _context.SaveChanges();

            return true;
        }

    }

}

