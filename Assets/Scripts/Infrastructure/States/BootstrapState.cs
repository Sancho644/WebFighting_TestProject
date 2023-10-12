using Infrastructure.AssetManagement;
using Infrastructure.Factory;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;
using Infrastructure.Services.Randomizer;
using StaticData;

namespace Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices()
        {
            RegisterStaticData();

            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IProgressService>(new ProgressService());
            _services.RegisterSingle<IRandomService>(new RandomService());

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IAssets>(),
                _services.Single<IStaticDataService>(),
                _services.Single<IProgressService>(),
                _services.Single<IRandomService>()));

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(
                _services.Single<IProgressService>(), 
                _services.Single<IGameFactory>()));
        }

        private void RegisterStaticData()
        {
            var staticData = new StaticDataService();
            staticData.LoadResources();
            _services.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}