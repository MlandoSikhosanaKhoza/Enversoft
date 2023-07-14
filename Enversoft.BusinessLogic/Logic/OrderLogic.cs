
using Enversoft.Shared;
using Enversoft.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Enversoft.BusinessLogic
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        public OrderLogic(IOrderRepository orderRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public List<Order> GetOngoingOrdersForCustomer(int CustomerId)
        {
            return _orderRepository.GetOngoingOrdersForCustomer(CustomerId);
        }

        public List<Order> GetCompleteOrdersForCustomer(int CustomerId)
        {
            return _orderRepository.GetCompleteOrdersForCustomer(CustomerId);
        }

        public List<Order> GetOngoingOrders()
        {
            return _orderRepository.GetOngoingOrders();
        }

        public List<Order> GetCompleteOrders()
        {
            return _orderRepository.GetCompleteOrders();
        }

        public List<CustomerOrderResult> GetNumberOfCustomerOrders()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            return _orderRepository.GetNumberOfCustomerOrders(customers);
        }

        public List<CustomerOrderPriceResult> GetTotalSpentOfCustomerOrders()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            return _orderRepository.GetTotalSpentOfCustomerOrders(customers);
        }

        public List<CustomerOrderPriceResult> GetAverageSpentOfCustomerOrders()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers();
            return _orderRepository.GetAverageSpentOfCustomerOrders(customers);
        }

        public Order AddOrder(Order Order)
        {
            return _orderRepository.AddOrder(Order);
        }

        public Order GetOrder(int OrderId)
        {
            return _orderRepository.GetOrder(OrderId);
        }

        public bool UpdateOrder(Order Order)
        {
            return _orderRepository.UpdateOrder(Order);
        }

        public bool DeleteOrder(int OrderId)
        {
            return _orderRepository.DeleteOrder(OrderId);
        }
    }
}
