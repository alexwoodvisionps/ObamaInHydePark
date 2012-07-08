using System.Configuration;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
    public class EmailerFactory
    {
        public static Emailer NewDefaultInstance()
        {
            return new Emailer(ConfigurationManager.AppSettings["SmtpServer"], ConfigurationManager.AppSettings["SmtpUsername"], ConfigurationManager.AppSettings["SmtpPassword"],25);
        }
        public static void SendDownloadLink(Order order, Order mapOrder)
        {
            var emailer = NewDefaultInstance();

            var name = order.Email;
            var body = "Hello " + name + ", <br/>This email is to let you know your download of Obama in Hyde Park's Audio/Visual Tour is ready to be downloaded go to <a href='http://obamainhydepark.com/Download.aspx?ordernumber=" + order.OrderNumber + "'>Our Download Page</a> To Download it today! <br/> Visit <a href='http://obamainhydepark.com/Map.aspx?OrderNumber=" + mapOrder.OrderNumber + "'>Our Map Section</a> For Exclusive Walking Directions <br/> Thank You! <br/> The Obama In Hyde Park Team";
            const string subject = "Obama In Hyde Park Team - Your download is ready of the Walking Tour You purchased!";
            emailer.SendHtmlEmail(ConfigurationManager.AppSettings["FromEmail"], order.Email, subject, body);
            
        }
    }
}