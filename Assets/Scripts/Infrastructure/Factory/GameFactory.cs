using System.Collections.Generic;
using Infrastructure.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;
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

        private Transform _uiRoot;
        private Transform _parent;

        public List<ISavedProgress> Progresses { get; } = new List<ISavedProgress>();

        public GameFactory(IAssets assets, IStaticDataService staticData, IProgressService progressService)
        {
            _assets = assets;
            _staticData = staticData;
            _progressService = progressService;
        }

        public void CreateSearchingEnemyScreen()
        {
            SearchParentTransform(ScreenId.EnemySearch);

            ScreensConfig config = _staticData.ForScreen(ScreenId.EnemySearch);
            EnemySearchScreen screen = Object.Instantiate(config.Prefab, _parent) as EnemySearchScreen;
            screen.Construct(_progressService);
        }

        public void CreateUIRoot()
        {
            GameObject root = _assets.Instantiate(UIRootPath);
            _uiRoot = root.transform;
        }

        public void CreateLoginScreen(ISaveLoadService saveLoadService)
        {
            SearchParentTransform(ScreenId.Login);

            var config = _staticData.ForScreen(ScreenId.Login);
            LoginScreen loginScreen = Object.Instantiate(config.Prefab, _parent) as LoginScreen;
            
            RegisterProgressWatchers(loginScreen.gameObject);
            
            loginScreen.Construct(_progressService, this, saveLoadService);
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

        private GameObject Instantiate(string prefabPath, RectTransform at)
        {
            return _assets.Instantiate(prefabPath, at);
        }
    }
}