using System.Collections.Generic;
using StaticData.Screens;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "ScreenData", menuName = "ScreenData/Screen")]
    public class ScreenStaticData : ScriptableObject
    {
        public List<ScreensConfig> ScreenConfigs;
    }
}