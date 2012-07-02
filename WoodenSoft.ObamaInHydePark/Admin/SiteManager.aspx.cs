using System;
using System.Configuration;
using System.Web.UI.WebControls;
using WoodenSoft.ObamaInHydePark.Components.BuisinessLogic.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;

namespace WoodenSoft.ObamaInHydePark.Admin
{
    public partial class SiteManager : System.Web.UI.Page
    {
        private readonly ISettingsRepository _settingRepository;
        private readonly IMapPointsRepository _mapPointsRepo;
        public SiteManager()
        {
            _mapPointsRepo = new MapPointRepository();
            _settingRepository = new SettingsRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            gvMapPoints.RowDeleting += new GridViewDeleteEventHandler(gvMapPoints_RowDeleting);
            if(!IsPostBack)
            {
                var settings = _settingRepository.GetSettings();
                if (settings != null)
                {
                    if (!string.IsNullOrEmpty(settings.ContactPhone))
                        txtPhone.Text = settings.ContactPhone;
                 
                    if (!string.IsNullOrEmpty(settings.AboutUs))
                        txtDescription.Text = settings.AboutUs;
                    if (!string.IsNullOrEmpty(settings.ContactAddress))
                        txtAddress.Text = settings.ContactAddress;
                    if (!string.IsNullOrEmpty(settings.LogoUrl))
                        imgCurrentLogo.ImageUrl = settings.LogoUrl;
                    if (!string.IsNullOrEmpty(settings.ContactEmail))
                        txtSiteMasterEmail.Text = settings.ContactEmail;
                    if (!string.IsNullOrEmpty(settings.Terms))
                        txtTerms.Text = settings.Terms;
                    if (!string.IsNullOrEmpty(settings.HomePageMessage))
                        txtHomePageMessage.Text = settings.HomePageMessage;
                    if (!string.IsNullOrEmpty(settings.ITunesUrl))
                        txtItunesUrl.Text = settings.ITunesUrl;
                }
             
            }
            BindMapPoints();
        }

        protected void gvMapPoints_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var id = int.Parse(gvMapPoints.Rows[e.RowIndex].Cells[0].Text);

        }
        private void BindMapPoints()
        {
            var points = _mapPointsRepo.GetAllPoints();
            if (points.Count == 0)
            {
                return;
            }
            gvMapPoints.DataSource = points;
            gvMapPoints.DataBind();
        }

        protected void btnSaveSettings_Click(object sender, EventArgs e)
        {
            
            var settings = _settingRepository.GetSettings() ?? new Settings();
            settings.ContactAddress = StringHelper.RemovePossibleXSS(txtAddress.Text);
            settings.AboutUs = StringHelper.RemovePossibleXSS(txtDescription.Text);
            settings.ITunesUrl = txtItunesUrl.Text;
            settings.ContactPhone = StringHelper.RemovePossibleXSS(txtPhone.Text);
            //ConfigurationManager.AppSettings["RollinSettingsDir"]
           
            
            settings.HomePageMessage = txtHomePageMessage.Text;
                
                   
            if(fuCompanyLogo.HasFile)
            {
                settings.LogoUrl = ConfigurationManager.AppSettings["SettingsDir"] + fuCompanyLogo.FileName;
                fuCompanyLogo.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["SettingsDir"]) + fuCompanyLogo.FileName);
            }
            else
            {
                if (settings.LogoUrl == null)
                    settings.LogoUrl = "";
            }
         
            if(!string.IsNullOrWhiteSpace(txtSiteMasterEmail.Text))
            {
                if (StringHelper.IsValidEmail(txtSiteMasterEmail.Text))
                    settings.ContactEmail = txtSiteMasterEmail.Text;
                else
                {
                    lblError.Text = "Site Administrator Email Address is invalid!";
                }
                
            }
            else
            {
                if (settings.ContactEmail == null)
                    settings.ContactEmail = "";
            }
            if(!string.IsNullOrEmpty(txtTerms.Text))
            {
                settings.Terms = txtTerms.Text;
            }
            else
            {
                if (settings.Terms == null)
                    settings.Terms = "";
            }
            _settingRepository.Save(settings);
            lblError.Text = "Settings Successfully Updated!";
            BindMapPoints();
        }

        protected void btnSaveMapPoint_Click(object sender, EventArgs e)
        {
            try
            {
                var mapPoints = _mapPointsRepo.GetAllPoints();
                var newPoint = new MapPoint {Address = txtMapPointAddress.Text, Name = txtMapPointName.Text};
                var coordinates = GeoCoder.GeoCode(txtMapPointAddress.Text);
                newPoint.Lat = coordinates.Lat;
                newPoint.Long = coordinates.Long;
                newPoint.Ordinal = int.Parse(txtMapPointOrdinal.Text);
                mapPoints.Add(newPoint);
                _mapPointsRepo.Save(mapPoints);
            }
            catch(Exception ex)
            {
                lblError.Text = "An Error Occurred Processing the New Walking Point Tour Stop " + ex.ToString();
            }
        }
    }
}