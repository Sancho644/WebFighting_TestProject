using System.Collections.Generic;
using System.Linq;
using Enemy;
using StaticData.Screens;
using UI.Screens;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataScreenPath = "StaticData/ScreenData";
        private const string StaticDataEnemiesPath = "StaticData/EnemyData";

        private Dictionary<ScreenId, ScreensConfig> _screenConfigs;
        private Dictionary<EnemyId, EnemyStaticData> _enemiesConfigs;

        public void LoadResources()
        {
            _screenConfigs = Resources
                .Load<ScreenStaticData>(StaticDataScreenPath)
                .ScreenConfigs
                .ToDictionary(x => x.ScreenId, x => x);

            _enemiesConfigs = Resources
                .LoadAll<EnemyStaticData>(StaticDataEnemiesPath)
                .ToDictionary(x => x.EnemyId, x => x);
        }

        public ScreensConfig ForScreen(ScreenId screenId)
        {
            return _screenConfigs.TryGetValue(screenId, out ScreensConfig screensConfig) ? screensConfig : null;
        }

        public EnemyStaticData ForEnemy(EnemyId enemyId)
        {
            return _enemiesConfigs.TryGetValue(enemyId, out EnemyStaticData enemyData) ? enemyData : null;
        }
    }
}