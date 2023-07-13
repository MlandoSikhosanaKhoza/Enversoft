using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface IWarehouseRepository
    {
        List<Warehouse> GetWarehouses();
    }
}
