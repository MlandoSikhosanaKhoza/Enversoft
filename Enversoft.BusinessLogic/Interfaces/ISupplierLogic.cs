using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.BusinessLogic
{
    public interface ISupplierLogic
    {
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int SupplierId);
        List<Supplier> SearchSuppliers(string Name);
        Supplier AddSupplier(Supplier SupplierObj);
        bool UpdateSupplier(Supplier SupplierObj);
    }
}
