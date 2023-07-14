
using Enversoft.Shared;
using Enversoft.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Enversoft.BusinessLogic
{
    public class OrderItemLogic:IOrderItemLogic
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IItemRepository _itemRepository;
        public OrderItemLogic(IOrderRepository orderRepository,IOrderItemRepository orderItemRepository,IItemRepository itemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _itemRepository = itemRepository;
        }

        public List<OrderItem> GetAllOrderItems()
        {
            return _orderItemRepository.GetAllOrderItems();
        }

        public List<OrderItemResult> GetOrderViewItems(int OrderId)
        {
            return _orderItemRepository.GetOrderViewItems(OrderId);
        }

        public OrderItem AddOrderItem(OrderItem OrderItem)
        {
            return _orderItemRepository.AddOrderItem(OrderItem);
        }

        public OrderItem GetOrderItem(int OrderItemId)
        {
            return _orderItemRepository.GetOrderItem(OrderItemId);
        }

        public bool UpdateOrderItem(OrderItem OrderItem)
        {
            return _orderItemRepository.UpdateOrderItem(OrderItem);
        }

        public bool DeleteOrderItem(int OrderItemId)
        {
            return _orderItemRepository.DeleteOrderItem(OrderItemId);
        }

        public List<OrderItem> AddOrderItems(int OrderId,int[] ItemId, int[] Quantity)
        {
            List<OrderItem> orderItems = new List<OrderItem>();
            for (int i = 0; i < ItemId.Length; i++)
            {
                OrderItem orderItem = _orderItemRepository.AddOrderItem(new OrderItem { OrderId = OrderId, ItemId = ItemId[i], Quantity = Quantity[i], Price = _itemRepository.GetItem(ItemId[i]).Price });
                orderItems.Add(orderItem);
            }
            Order order = _orderRepository.GetOrder(OrderId);
            order.Subtotal = orderItems.Sum(o => o.Quantity * o.Price);
            order.GrandTotal = order.Subtotal * 1.15m;
            _orderRepository.UpdateOrder(order);
            return orderItems;
        }
    }
}
