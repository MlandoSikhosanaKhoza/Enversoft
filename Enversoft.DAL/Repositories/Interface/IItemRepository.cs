using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        Item AddItem(Item ItemToAdd);
        Item GetItem(int ItemId);
        bool UpdateItem(Item ItemToUpdate);
        bool DeleteItem(int ItemId);
    }
}
