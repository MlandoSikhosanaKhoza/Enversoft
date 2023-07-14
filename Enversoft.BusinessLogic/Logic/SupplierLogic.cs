using Enversoft.DAL;
using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.BusinessLogic
{
    public class SupplierLogic:ISupplierLogic
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierLogic(ISupplierRepository supplierRepository) {
            _supplierRepository = supplierRepository;
        }

        public List<Supplier> GetSuppliers()
        {
            return _supplierRepository.GetSuppliers();
        }

        public Supplier GetSupplierById(int SupplierId)
        {
            return _supplierRepository.GetSupplierById(SupplierId);
        }

        public List<Supplier> SearchSuppliers(string Name)
        {
            return _supplierRepository.SearchSuppliers(Name);
        }

        public Supplier AddSupplier(Supplier SupplierObj)
        {
            return _supplierRepository.AddSupplier(SupplierObj);
        }

        public bool UpdateSupplier(Supplier SupplierObj) {
            return _supplierRepository.UpdateSupplier(SupplierObj);
        }
    }
}
