using System.Collections.Generic;
using System.Linq;
using StaticData.Screens;
using UI.Screens;
using UnityEngine;

namespace StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataScreenPath = "StaticData/ScreenData";
        
        private Dictionary<ScreenId, ScreensConfig> _screenConfigs;

        public void LoadResources()
        { 
            _screenConfigs = Resources
                .Load<ScreenStaticData>(StaticDataScreenPath)
                .ScreenConfigs
                .ToDictionary(x=>x.ScreenId, x => x);
        }

        public ScreensConfig ForScreen(ScreenId screenId)
        {
             return _screenConfigs.TryGetValue(screenId, out ScreensConfig screensConfig) ? screensConfig : null;
        }
    }
}