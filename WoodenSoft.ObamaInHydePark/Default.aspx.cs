using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;

namespace WoodenSoft.ObamaInHydePark
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var images = new ImageRepository().GetAll();
            //<div class="slide">
            //            <a href="http://www.flickr.com/photos/bu7amd/3447416780/" title="&ldquo;I must go down to the sea again, to the lonely sea and the sky; and all I ask is a tall ship and a star to steer her by.&rdquo; | Flickr - Photo Sharing!" target="_blank"><img src="img/slide-5.jpg" width="570" height="270" alt="Slide 5"></a>
            //            <div class="caption">
            //                <p>&ldquo;I must go down to the sea again, to the lonely sea and the sky...&rdquo;</p>
            //            </div>
            //        </div>
            var sb = new StringBuilder();
            foreach (var image in images)
            {
                sb.Append("<div class='slide'>");
                sb.AppendLine("<a href='#' title='" + image.Name + "' target='_blank'>");
                sb.AppendLine("<img src='" + image.Url + "' alt='" + image.Name + "' width='570' height='270' /></a>");
                sb.AppendLine("<div class='caption' style='color : white'><p>" + image.Name + "</p></div></div>");
            }
            litCarousel.Text = sb.ToString();
            var settings = new SettingsRepository().GetSettings();
            if (settings == null)
                return;
            litMessage.Text = settings.HomePageMessage;
        }
    }
}