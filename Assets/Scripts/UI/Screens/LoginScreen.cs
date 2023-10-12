using Data;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.PersistentProgress.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class LoginScreen : ScreenBase, ISavedProgress
    {
        [SerializeField] private InputField _playerName;
        [SerializeField] private Button _continueButton;

        private IGameFactory _gameFactory;
        private ISaveLoadService _saveLoadService;

        public void Construct(IProgressService progressService, IGameFactory gameFactory, ISaveLoadService saveLoadService)
        {
            base.Construct(progressService);

            _gameFactory = gameFactory;
            _saveLoadService = saveLoadService;
        }

        private void Start()
        {
            _continueButton.onClick.AddListener(OnContinue);
        }

        private void Update()
        {
            var inputFieldIsEmpty = _playerName.text == string.Empty;
            _continueButton.interactable = !inputFieldIsEmpty;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.PlayerData.PlayerName = _playerName.text;
        }

        public void LoadProgress(PlayerProgress progress)
        {
        }

        private void OnContinue()
        {
            Progress.WorldData.PlayerData.PlayerName = _playerName.text;
            _gameFactory.CreateSearchingEnemyScreen();
            _saveLoadService.SaveProgress();
            
            Destroy(gameObject);
        }
    }
}