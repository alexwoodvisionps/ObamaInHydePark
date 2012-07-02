using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order);
        List<Order> GetAllOrders();
        void FulFillOrder(Order order);
        bool ValidateOrder(string orderNumber);
        Order GetById(int id);
    }
}
