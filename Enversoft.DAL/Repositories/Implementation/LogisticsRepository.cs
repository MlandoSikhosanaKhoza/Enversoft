using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public class LogisticsRepository:ILogisticsRepository
    {
        private readonly IGenericRepository<Logistics> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public LogisticsRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Logistics>();
        }

        public List<Logistics> GetLogisticsList()
        {
            return _repository.Get().ToList();
        }

        public bool DeleteLogistics(Logistics LogisticsObject)
        {
            _repository.Delete(LogisticsObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool DeleteLogisticsById(int LogisticsId)
        {
            _repository.DeleteById(LogisticsId);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateLogistics(Logistics LogisticsObject)
        {
            _repository.Update(LogisticsObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public Logistics AddLogistics(Logistics LogisticsObject)
        {
            Logistics LogisticsAdded = _repository.Insert(LogisticsObject);
            _unitOfWork.SaveChanges();
            return LogisticsAdded;
        }
    }
}
