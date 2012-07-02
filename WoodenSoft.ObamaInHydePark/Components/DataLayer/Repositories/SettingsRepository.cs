using System;
using System.Data.SqlClient;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories
{
    public class SettingsRepository : GenericRepository<Settings>, ISettingsRepository
    {
        public Settings GetSettings()
        {
            var dt = ExecuteQuery("SELECT Top 1 * From Settings");
            if (dt.Rows.Count == 0)
                return null;
            return dt.Rows[0].DataRowToModel<Settings>(new Settings());
        }

        public void Save(Settings settings)
        {
            ExecuteNonQuery("DELETE FROM Settings");
            var parameters = new[]
                                 {
                                     new SqlParameter("@AboutUs", settings.AboutUs), 
                                     new SqlParameter("@Address", settings.ContactAddress),
                                     new SqlParameter("@LogoUrl", settings.LogoUrl),
                                     new SqlParameter("@Phone", settings.ContactPhone),
                                     new SqlParameter("@Message", settings.HomePageMessage), 
                                     new SqlParameter("@Email", settings.ContactEmail),
                                     new SqlParameter("@terms", settings.Terms),
                                     new SqlParameter("@itunes", settings.ITunesUrl) 
                                 };
            const string sql = "INSERT INTO SETTINGS (ContactEmail,Terms,AboutUs, ContactAddress, LogoUrl, ContactPhone, HomePageMessage, ITunesUrl)" +
                               " VALUES(@Email, @terms, @AboutUs, @Address, @LogoUrl, @Phone, @Message, @itunes)";
            ExecuteNonQuery(sql, parameters);
        }
    }
}