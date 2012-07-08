using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Common;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories
{
    public class MapPointRepository : GenericRepository<MapPoint>, IMapPointsRepository
    {
        public void Save(MapPoint mapPoint)
        {

            var param = new[]
                            {
                                new SqlParameter("@Lat", mapPoint.Lat),
                                new SqlParameter("@Long", mapPoint.Long),
                                new SqlParameter("@ordinal", mapPoint.Ordinal),
                                new SqlParameter("@address", mapPoint.Address),
                                new SqlParameter("@name", mapPoint.Name)
                            };
            
            {
                ExecuteNonQuery(
                    "INSERT INTO MapPoints(Ordinal, Long, Lat, Name, [Address]) Values(@ordinal, @Long, @Lat, @name, @address)",
                    param);
            }
        }

        public void Delete(int id)
        {
            ExecuteNonQuery("Delete From MapPoints WHERE Id = " + id);
        }

        public List<MapPoint> GetAllPoints()
        {
            return ExecuteQuery("SELECT * FROM MapPoints").DataTableToList<MapPoint>(new MapPoint());
        }
    }
} 