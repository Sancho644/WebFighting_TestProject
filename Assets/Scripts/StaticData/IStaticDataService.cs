using Infrastructure.Services;
using StaticData.Screens;
using UI.Screens;

namespace StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadResources();
        ScreensConfig ForScreen(ScreenId screenId);
    }
}