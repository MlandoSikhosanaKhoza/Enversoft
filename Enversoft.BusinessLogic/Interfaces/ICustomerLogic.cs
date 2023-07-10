﻿using Enversoft.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enversoft.BusinessLogic
{
    public interface ICustomerLogic
    {
        List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer Customer);
        Customer ConfigureCustomer(Customer Customer);
        Customer GetCustomer(int CustomerId);
        Customer GetCustomerByMobileNumber(string MobileNumber);
        bool UpdateCustomer(Customer Customer);
        bool DeleteCustomer(int CustomerId);
        List<Customer> SearchForCustomers(string Search);
        bool MobileNumberExists(string Mobile);
    }
}
