using WoodenSoft.ObamaInHydePark.Components.DataLayer.Models;

namespace WoodenSoft.ObamaInHydePark.Components.DataLayer.Repositories.Interfaces
{
    public interface ISettingsRepository
    {
        Settings GetSettings();
        void Save(Settings settings);
    }
}
