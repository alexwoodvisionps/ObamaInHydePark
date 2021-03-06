﻿using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Common;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
namespace WoodenSoft.ObamaInHydePark.Admin
{
    public partial class Billing : System.Web.UI.Page
    {
        private readonly IOrderRepository _orderRepo;
        public Billing()
        {
            _orderRepo = new OrderRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
            if(!IsPostBack)
            {
                ViewState["sortField"] = "Email";
                ViewState["sortDirection"] = "ASC";
            }
            BindData();
            gvUsers.Sorting += new GridViewSortEventHandler(gvUsers_Sorting);
            gvUsers.PageIndexChanging += new GridViewPageEventHandler(gvUsers_PageIndexChanging);
        }

        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindData();
            gvUsers.PageIndex = e.NewPageIndex;
        }

        protected void gvUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            if(ViewState["sortField"].ToString() == e.SortExpression)
            {
                if (ViewState["sortDirection"].ToString() == "ASC")
                    ViewState["sortDirection"] = "DESC";
                else
                {
                    ViewState["sortDirection"] = "ASC";
                }
            }
            else
            {
                ViewState["sortDirection"] = "ASC";
                ViewState["sortField"] = e.SortExpression;
            }
        }
        private void BindData()
        {
            var orders = _orderRepo.GetAllOrders();
            orders = ViewState["sortDirection"].ToString() == "ASC"
                        ? orders.OrderBy(x => x.GetProperty(ViewState["sortField"].ToString())).ToList()
                        : orders.OrderByDescending(x => x.GetProperty(ViewState["sortField"].ToString())).ToList();
            gvUsers.DataSource = orders;
            gvUsers.DataBind();
        }
        protected void ResetOrderNumber(object sender, EventArgs e)
        {
            var orderNumber = ((Button) sender).CommandArgument;
            var orders = _orderRepo.GetAllOrders().Where(x => x.OrderNumber == orderNumber);
            foreach (var order in orders)
            {
                _orderRepo.Reset(order);
            }
            lblError.Text = "<strong>Order Reset Successfully</strong>";
            BindData();
        }

        protected void EmailCustomer(object sender, EventArgs e)
        {
            var orderNumber = ((Button) sender).CommandArgument;
            var orders = _orderRepo.GetAllOrders().Where(x => x.OrderNumber == orderNumber).ToArray();
            EmailerFactory.SendDownloadLink(orders[0], orders[1]);
            lblError.Text = "<strong>Order Sent To Customer Successfully</strong>";
            BindData();
        }
    }
}