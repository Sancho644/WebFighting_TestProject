using System.Collections;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Newtonsoft.Json;
using UI.Elements;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EnemySearch : ScreenBase
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Button _enemySearchingButton;
        [SerializeField] private Button _enemyFightButton;
        [SerializeField] private EnemySearchScreen _enemySearchScreen;
        [SerializeField] private LootCounter _lootCounter;
        [Space]
        [SerializeField] private string _url;

        private IGameFactory _gameFactory;
        
        private string _enemyIconUrl;
        private string _enemyName;
        private string _playerName;
        private string _coins;
        
        private Texture2D _enemyIcon;

        public void Construct(IProgressService progressService, IGameFactory gameFactory)
        {
            base.Construct(progressService);
            
            _gameFactory = gameFactory;
        }
        
        protected override void Initialize()
        {
            _lootCounter.Construct(Progress.WorldData);
            
            SubscribeButtons();
            RequestEnemyInfo();
            RefreshPlayerNameText();
            RefreshCoinsText();
        }

        private void SubscribeButtons()
        {
            _enemySearchingButton.onClick.AddListener(RequestEnemyInfo);
            _enemyFightButton.onClick.AddListener(StartFight);
        }

        private void StartFight()
        {
            _gameFactory.CreateEnemyFightScreen();
            
            Destroy(gameObject);
        }

        private void RequestEnemyInfo()
        {
            LoadingScreenSwitch(true);
            StartCoroutine(SendRequests());
        }

        private void RefreshCoinsText()
        {
            _coins = Progress.WorldData.LootData.Collected.ToString();
        }

        private void RefreshPlayerNameText()
        {
            _playerName = Progress.WorldData.PlayerData.PlayerName;
        }

        private IEnumerator SendRequests()
        {
            UnityWebRequest request = UnityWebRequest.Get(_url);

            yield return request.SendWebRequest();

            LoadingScreenSwitch(false);
            UpdateEnemyName(request);

            UnityWebRequest enemyIconRequest = UnityWebRequest.Get(_enemyIconUrl);

            yield return enemyIconRequest.SendWebRequest();
            
            UpdateEnemyIcon(enemyIconRequest);
            SetEnemySearchScreenInfo();
        }

        private void SetEnemySearchScreenInfo()
        {
            _enemySearchScreen.SetProgressInfo(_playerName, _coins, _enemyName, _enemyIcon);
        }

        private void LoadingScreenSwitch(bool value)
        {
            _loadingScreen.SetActive(value);
        }

        private void UpdateEnemyIcon(UnityWebRequest enemyIconRequest)
        {
            var texture = new Texture2D(100, 100);
            texture.LoadImage(enemyIconRequest.downloadHandler.data);
            _enemyIcon = texture;
        }

        private void UpdateEnemyName(UnityWebRequest request)
        {
            EnemyConfig enemyConfig = JsonConvert.DeserializeObject<EnemyConfig>(request.downloadHandler.text);

            foreach (Result result in enemyConfig.results)
            {
                _enemyName = $"{result.name.title} {result.name.first} {result.name.last}";
                Progress.WorldData.EnemyData.SetName(_enemyName);
                
                _enemyIconUrl = result.picture.thumbnail;
            }
        }
    }
}