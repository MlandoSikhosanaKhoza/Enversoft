using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enversoft.DAL
{
    public class SupplierRepository:ISupplierRepository
    {
        private IGenericRepository<Supplier> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public SupplierRepository(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<Supplier>();
        }

        public List<Supplier> GetSuppliers()
        {
            return _repository.GetAll().ToList();
        }

        public List<Supplier> SearchSuppliers(string Name)
        {
            return _repository.Get(s => s.Name.ToLower().Contains(Name.ToLower())).ToList();
        }

        public bool DeleteSupplier(Supplier SupplierObject)
        {
            _repository.Delete(SupplierObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public bool UpdateSupplier(Supplier SupplierObject)
        {
            _repository.Update(SupplierObject);
            _unitOfWork.SaveChanges();
            return true;
        }

        public Supplier AddSupplier(Supplier SupplierObject)
        {
            Supplier addedSupplier = _repository.Insert(SupplierObject);
            _unitOfWork.SaveChanges();
            return addedSupplier;
        }
    }
}
