using System.Collections.Generic;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        void CreateSearchingEnemyScreen();
        void CreateUIRoot();
        void CreateLoginScreen(ISaveLoadService saveLoadService);
        List<ISavedProgress> Progresses { get; }
    }
}