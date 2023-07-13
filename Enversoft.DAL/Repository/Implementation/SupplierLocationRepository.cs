using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public class SupplierLocationRepository:ISupplierLocationRepository
    {
        private readonly IGenericRepository<SupplierLocation> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierLocationRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<SupplierLocation>();
        }

        public List<SupplierLocation> GetSupplierLocations()
        {
            return _repository.Get().ToList();
        }

        public bool DeleteSupplierLocation(SupplierLocation SupplierLocationObject)
        {
            _repository.Delete(SupplierLocationObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateSupplierLocation(SupplierLocation SupplierLocationObject)
        {
            _repository.Update(SupplierLocationObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public SupplierLocation AddSupplierLocation(SupplierLocation SupplierLocationObject)
        {
            SupplierLocation SupplierLocationAdded = _repository.Insert(SupplierLocationObject);
            _unitOfWork.SaveChanges();
            return SupplierLocationAdded;
        }
    }
}
