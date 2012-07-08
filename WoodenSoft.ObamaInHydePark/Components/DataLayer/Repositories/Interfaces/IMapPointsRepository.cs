using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces
{
    public interface IMapPointsRepository
    {
        void Save(MapPoint mapPoint);
        List<MapPoint> GetAllPoints();
        void Delete(int id);
    }
}
