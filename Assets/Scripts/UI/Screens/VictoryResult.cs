using Enemy;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class VictoryResult : ScreenBase
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private VictoryResultScreen _resultScreen;

        private IStaticDataService _staticData;
        private IRandomService _randomService;
        private IGameFactory _gameFactory;

        private string _enemyName;
        private int _coins;

        public void Construct(IProgressService progressService, IStaticDataService staticData, IRandomService randomService, IGameFactory gameFactory)
        {
            base.Construct(progressService);

            _staticData = staticData;
            _randomService = randomService;
            _gameFactory = gameFactory;
        }

        protected override void Initialize()
        {
            _continueButton.onClick.AddListener(ContinueSearch);

            _enemyName = Progress.WorldData.EnemyData.EnemyName;

            SetReward();
            UpdateProgressResultInfo();
        }

        private void UpdateProgressResultInfo()
        {
            _resultScreen.SetResultInfo(_enemyName, _coins.ToString());
            Progress.WorldData.LootData.Add(_coins);
        }

        private void SetReward()
        {
            EnemyStaticData staticData = _staticData.ForEnemy(EnemyId.BaseEnemy);
            SetCoinsCount(_randomService.Next(staticData.MinReward, staticData.MaxReward));
        }

        private void SetCoinsCount(int coins)
        {
            _coins = coins;
        }

        private void ContinueSearch()
        {
            _gameFactory.CreateSearchingEnemyScreen();

            Destroy(gameObject);
        }
    }
}