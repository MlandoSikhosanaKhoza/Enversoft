using AutoMapper;
using Enversoft.Shared;

namespace Enversoft.Web.Models.Profiles
{
    public class SupplierProfiler:Profile
    {
        public SupplierProfiler()
        {
            CreateMap<SupplierModel, Supplier>();
            CreateMap<Supplier, SupplierModel>();
        }
    }
}
