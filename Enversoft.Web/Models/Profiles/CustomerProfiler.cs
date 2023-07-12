using AutoMapper;
using Enversoft.Shared;

namespace Enversoft.Web.Models.Profiles
{
    public class CustomerProfiler : Profile
    {
        public CustomerProfiler()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
        }
    }
}
