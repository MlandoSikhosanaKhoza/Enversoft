using AutoMapper;
using Enversoft.Shared;

namespace Enversoft.Web.Models.Profiles
{
    public class OrderProfiler : Profile
    {
        public OrderProfiler()
        {
            CreateMap<OrderModel, Order>();
            CreateMap<Order, OrderModel>();
        }
    }
}
