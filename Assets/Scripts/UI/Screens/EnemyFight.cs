using Enemy;
using Infrastructure.Factory;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.Randomizer;
using StaticData;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EnemyFight : ScreenBase
    {
        [SerializeField] private Button _enemy;
        [SerializeField] private ActorUI _actorUI;
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private EnemyFightScreen _enemyFight;

        private IStaticDataService _staticData;
        private IRandomService _randomService;
        private IGameFactory _gameFactory;

        private string _enemyName;
        private int _damage;

        public void Construct(IProgressService progressService, IStaticDataService staticData,
            IRandomService randomService, IGameFactory gamaFactory)
        {
            base.Construct(progressService);

            _staticData = staticData;
            _randomService = randomService;
            _gameFactory = gamaFactory;
        }

        protected override void Initialize()
        {
            _enemy.onClick.AddListener(TakeDamage);

            _actorUI.Construct(_enemyHealth);

            SetEnemyName();
            UpdateEnemyStats();
        }

        public void OnEnemyDeath()
        {
            _gameFactory.CreateVictoryScreen();

            Destroy(gameObject);
        }

        private void SetEnemyName()
        {
            _enemyName = Progress.WorldData.EnemyData.EnemyName;
            _enemyFight.SetEnemyName(_enemyName);
        }

        private void UpdateEnemyStats()
        {
            EnemyStaticData staticData = _staticData.ForEnemy(EnemyId.BaseEnemy);

            SetEnemyHealth(_randomService.Next(staticData.MinHp, staticData.MaxHp));
            SetEnemyDamage(_randomService.Next(staticData.MinDamage, staticData.MaxDamage));
        }

        private void SetEnemyDamage(int damage)
        {
            _damage = damage;
        }

        private void SetEnemyHealth(int health)
        {
            _enemyHealth.Current = health;
            _enemyHealth.Max = health;
        }

        private void TakeDamage()
        {
            _enemyHealth.TakeDamage(_damage);
        }
    }
}