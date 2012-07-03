using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void PlaceOrder(Order order, ProcessedValue type);
        List<Order> GetAllOrders();
        void FulFillOrder(Order order);
        bool ValidateOrder(string orderNumber, ProcessedValue notProcessedNumber);
        Order GetById(int id);
        void Reset(Order order);
    }
}
