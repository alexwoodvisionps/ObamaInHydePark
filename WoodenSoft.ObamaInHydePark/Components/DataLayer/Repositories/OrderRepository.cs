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
        public void PlaceOrder(Order order)
        {
            ExecuteNonQuery(
                "INSERT INTO Orders(HasBeenProcessed, Email, OrderNumber) Values(0, @email, '" +
                order.OrderNumber + "')",
                new[] {new SqlParameter("@email", order.Email)});
        }
        public bool ValidateOrder(string orderNumber)
        {
            var dt =
                ExecuteQuery("SELECT * FROM Orders WHERE OrderNumber = '" + orderNumber +
                             "' AND HasBeenProcessed = 0");
            return dt.Rows.Count > 0;
        }

        public Order GetById(int id)
        {
            return base.GetById(id, "Orders", new Order());
        }

        public List<Order> GetAllOrders()
        {
            return ExecuteQuery("SELECT * FROM Orders").DataTableToList<Order>(new Order());
        }

        public void FulFillOrder(Order order)
        {
            ExecuteNonQuery("Update Orders Set HasBeenProcessed = 1 WHERE OrderNumber = " + order.OrderNumber);
        }
    }
}