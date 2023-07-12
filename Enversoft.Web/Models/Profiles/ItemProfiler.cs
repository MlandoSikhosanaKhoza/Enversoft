using AutoMapper;
using Enversoft.Shared;


namespace Enversoft.Web.Models.Profiles
{
    public class ItemProfiler : Profile
    {
        public ItemProfiler()
        {
            CreateMap<ItemModel, ItemInputModel>();
            CreateMap<Item, ItemModel>();
        }
    }
}
