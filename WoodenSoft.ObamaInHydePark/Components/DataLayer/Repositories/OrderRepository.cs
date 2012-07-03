using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories
{
    public class OrderRepository: GenericRepository<Order>, IOrderRepository
    {
        public void PlaceOrder(Order order, ProcessedValue type)
        {
            ExecuteNonQuery(
                "INSERT INTO Orders(HasBeenProcessed, Email, OrderNumber) Values(" + ((int)type) + ", @email, '" +
                order.OrderNumber + "')",
                new[] {new SqlParameter("@email", order.Email)});
        }
        public bool ValidateOrder(string orderNumber, ProcessedValue notProcessedNumber)
        {
            var dt =
                ExecuteQuery("SELECT * FROM Orders WHERE OrderNumber = '" + orderNumber +
                             "' AND HasBeenProcessed = " + ((int)notProcessedNumber));
            return dt.Rows.Count > 0;
        }

        public Order GetById(int id)
        {
            return base.GetById(id, "Orders", new Order());
        }

        public void Reset(Order order)
        {
            if (order.HasBeenProcessed % 2 == 0)
                return;
            ExecuteNonQuery("Update Orders Set HasBeenProcessed = " + (order.HasBeenProcessed - 1) + " WHERE Id = " + order.Id);
        }

        public List<Order> GetAllOrders()
        {
            return ExecuteQuery("SELECT * FROM Orders").DataTableToList<Order>(new Order());
        }

        public void FulFillOrder(Order order)
        {
            if (order.HasBeenProcessed % 2 == 1)
                return;
            ExecuteNonQuery("Update Orders Set HasBeenProcessed = " + (order.HasBeenProcessed +1) + " WHERE Id = " + order.Id);
        }
    }
}