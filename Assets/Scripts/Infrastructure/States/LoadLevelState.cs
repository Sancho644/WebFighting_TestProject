using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string GameScene = "GameScene";

        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IProgressService _progressService;

        public LoadLevelState(SceneLoader sceneLoader, IGameFactory gameFactory, ISaveLoadService saveLoadService, IProgressService progressService)
        {
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
            _progressService = progressService;
        }

        public void Enter()
        {
            _sceneLoader.Load(GameScene, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            InitUIRoot();
            InitGameWorld();
        }

        private void InitUIRoot()
        {
            _gameFactory.CreateUIRoot();
        }

        private void InitGameWorld()
        {
            if (_progressService.Progress.WorldData.PlayerData.PlayerName != null)
                _gameFactory.CreateSearchingEnemyScreen();
            else
                InitLoginScreen();
        }

        private void InitLoginScreen()
        {
            _gameFactory.CreateLoginScreen(_saveLoadService);
        }
    }
}