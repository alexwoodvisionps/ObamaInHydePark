﻿using System;
using System.IO;
using System.Linq;
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
        private readonly IImageRepository _imageRepo;
        public SiteManager()
        {
            _imageRepo = new ImageRepository();
            _mapPointsRepo = new MapPointRepository();
            _settingRepository = new SettingsRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
         
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
            BindImages();
            BindMapPoints();
        }

        protected void DeleteMapPoint(object sender, EventArgs e)
        {
            var id = int.Parse(((Button) sender).CommandArgument);
            _mapPointsRepo.Delete(id);
            BindMapPoints();
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
        protected void DeleteImage(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            var id = int.Parse(btn.CommandArgument);
            var img = _imageRepo.GetAll().Single(x => x.Id == id);
            _imageRepo.Delete(id);
            File.Delete(Server.MapPath(img.Url));
            BindImages();
            BindMapPoints();
        }
        protected void BindImages()
        {
            gvImages.DataSource = _imageRepo.GetAll().OrderBy(x => x.Name).ToList();
            gvImages.DataBind();
        }

        protected void UploadImage(object sender, EventArgs e)
        {
            _imageRepo.Save(new Components.DataLayer.Models.Image{Name = txtStopName.Text, Url = ConfigurationManager.AppSettings["ImageDir"]  + fuTourImage.FileName});
            fuTourImage.SaveAs(Server.MapPath(ConfigurationManager.AppSettings["ImageDir"])  + fuTourImage.FileName);
            BindImages();
            BindMapPoints();
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
                //var mapPoints = _mapPointsRepo.GetAllPoints();
                var newPoint = new MapPoint {Address = txtMapPointAddress.Text, Name = txtMapPointName.Text};
                var coordinates = GeoCoder.GeoCode(txtMapPointAddress.Text);
                newPoint.Lat = coordinates.Lat;
                newPoint.Long = coordinates.Long;
                newPoint.Ordinal = int.Parse(txtMapPointOrdinal.Text);
                //mapPoints.Add(newPoint);
                _mapPointsRepo.Save(newPoint);
                BindMapPoints();
            }
            catch(Exception ex)
            {
                lblError.Text = "An Error Occurred Processing the New Walking Point Tour Stop " + ex.ToString();
            }
        }
    }
}