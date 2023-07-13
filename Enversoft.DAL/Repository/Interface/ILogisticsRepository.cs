using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public interface ILogisticsRepository
    {
        List<Logistics> GetLogisticsList();
        bool DeleteLogistics(Logistics LogisticsObject);
        bool UpdateLogistics(Logistics LogisticsObject);
        Logistics AddLogistics(Logistics LogisticsObject);
        bool DeleteLogisticsById(int LogisticsId);
    }
}
