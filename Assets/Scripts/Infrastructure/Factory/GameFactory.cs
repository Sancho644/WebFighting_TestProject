using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;
using Infrastructure.Services.Randomizer;
using StaticData;
using StaticData.Screens;
using UI;
using UI.Screens;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string UIRootPath = "UI/UIRoot";

        private readonly IAssets _assets;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private readonly IRandomService _randomService;

        private Transform _uiRoot;
        private Transform _parent;

        public List<ISavedProgress> Progresses { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets, IStaticDataService staticData, IProgressService progressService, IRandomService randomService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
            _randomService = randomService;
        }

        public void CreateLoginScreen(ISaveLoadService saveLoadService)
        {
            SearchParentTransform(ScreenId.Login);

            var config = _staticData.ForScreen(ScreenId.Login);
            LoginScreen loginScreen = Object.Instantiate(config.Prefab, _parent) as LoginScreen;

            RegisterProgressWatchers(loginScreen.gameObject);

            loginScreen.Construct(_progressService, this, saveLoadService);
        }

        public void CreateSearchingEnemyScreen()
        {
            SearchParentTransform(ScreenId.EnemySearch);

            ScreensConfig config = _staticData.ForScreen(ScreenId.EnemySearch);
            EnemySearch enemySearch = Object.Instantiate(config.Prefab, _parent) as EnemySearch;
            enemySearch.Construct(_progressService, this);
        }

        public void CreateEnemyFightScreen()
        {
            SearchParentTransform(ScreenId.EnemyFight);

            ScreensConfig config = _staticData.ForScreen(ScreenId.EnemyFight);
            EnemyFight enemyFight = Object.Instantiate(config.Prefab, _parent) as EnemyFight;
            enemyFight.Construct(_progressService, _staticData, _randomService, this);
        }

        public void CreateVictoryScreen()
        {
            SearchParentTransform(ScreenId.Victory);

            ScreensConfig config = _staticData.ForScreen(ScreenId.Victory);
            VictoryResult victory = Object.Instantiate(config.Prefab, _parent) as VictoryResult;
            victory.Construct(_progressService, _staticData, _randomService, this);
        }

        public void CreateUIRoot()
        {
            GameObject root = _assets.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }

        private void SearchParentTransform(ScreenId screenId)
        {
            List<ScreenParent> parentsList = _uiRoot.GetComponent<ScreenParentsList>().Parents;
            foreach (ScreenParent parent in parentsList)
            {
                if (parent.ScreenId == screenId)
                    _parent = parent.Parent;
            }
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgress progress in gameObject.GetComponents<ISavedProgress>())
            {
                Progresses.Add(progress);
            }
        }
    }
}