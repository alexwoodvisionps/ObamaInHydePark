using System.Configuration;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common
{
    public class EmailerFactory
    {
        public static Emailer NewDefaultInstance()
        {
            return new Emailer(ConfigurationManager.AppSettings["SmtpServer"], ConfigurationManager.AppSettings["SmtpUsername"], ConfigurationManager.AppSettings["SmtpPassword"]);
        }
        public static void SendDownloadLink(Order order)
        {
            var emailer = NewDefaultInstance();

            var name = order.Email;
            var body = "Hello " + name + ", <br/>This email is to let you know your download of Obama in Hyde Park's Audio/Visual Tour is ready to be downloaded go to <a href='obamainhydepark.com/download?ordernumber=" + order.OrderNumber + "' To Download it today! <br/> Thank You! <br/> The Obama In Hyde Park Team";
            const string subject = "Obama In Hyde Park Team - Your download is ready of the Walking Tour You purchased!";
            emailer.SendHtmlEmail(ConfigurationManager.AppSettings["FromEmail"], order.Email, subject, body);
        }
    }
}