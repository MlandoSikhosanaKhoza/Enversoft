
using Enversoft.Shared;
using Enversoft.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Enversoft.BusinessLogic
{
    public class CustomerLogic:ICustomerLogic
    {
        private ICustomerRepository _customerRepository { get; set; }
        private IUnitOfWork _unitOfWork;
        public CustomerLogic(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public List<Customer> SearchForCustomers(string Search)
        {
            return _customerRepository.SearchForCustomers(Search);
        }
        public bool MobileNumberExists(string Mobile)
        {
            return _customerRepository.MobileNumberExists( Mobile);
        }
        public Customer AddCustomer(Customer Customer)
        {
            return _customerRepository.AddCustomer(Customer);
        }
        public bool UpdateCustomer(Customer Customer)
        {
            return _customerRepository.UpdateCustomer(Customer);
        }
        public bool DeleteCustomer(int CustomerId)
        {
            return _customerRepository.DeleteCustomer(CustomerId);
        }
        public Customer GetCustomer(int CustomerId)
        {
            return _customerRepository.GetCustomer(CustomerId);
        }

        public Customer GetCustomerByMobileNumber(string MobileNumber)
        {
            return _customerRepository.GetCustomerByMobileNumber(MobileNumber);
        }

        public Customer ConfigureCustomer(Customer Customer)
        {
            return _customerRepository.ConfigureCustomer(Customer);
        }
    }
}
