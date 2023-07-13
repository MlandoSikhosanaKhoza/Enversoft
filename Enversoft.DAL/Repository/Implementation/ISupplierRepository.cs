using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface ISupplierRepository
    {
        List<Supplier> GetSuppliers();
        bool DeleteSupplier(Supplier SupplierObject);
        bool UpdateSupplier(Supplier SupplierObject);
        Supplier AddSupplier(Supplier SupplierObject);
    }
}
