using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces
{
    public interface IImageRepository
    {
        void Save(Image img);
        void Delete(int id);
        IEnumerable<Image> GetAll();
    }
}
