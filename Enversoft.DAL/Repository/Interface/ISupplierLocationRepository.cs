using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface ISupplierLocationRepository
    {
        List<SupplierLocation> GetSupplierLocations();
        bool DeleteSupplierLocation(SupplierLocation SupplierLocationObject);
        bool UpdateSupplierLocation(SupplierLocation SupplierLocationObject);
        SupplierLocation AddSupplierLocation(SupplierLocation SupplierLocationObject);
    }
}
