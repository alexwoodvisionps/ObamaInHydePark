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
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public void Save(Image img)
        {
            var sqlParams = new[] {new SqlParameter("@name", img.Name), new SqlParameter("@url", img.Url)};
            ExecuteNonQuery("INSERT INTO Images(Name, Url) Values(@name, @url)", sqlParams);
        }

        public void Delete(int id)
        {
            ExecuteNonQuery("DELETE FROM Images WHERE Id = " + id);
        }

        public IEnumerable<Image> GetAll()
        {
            return ExecuteQuery("SELECT * FROM Images").DataTableToList<Image>(new Image());
        }
    }
}