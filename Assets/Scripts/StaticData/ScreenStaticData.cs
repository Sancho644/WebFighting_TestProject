using System.Collections.Generic;
using StaticData.Screens;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "StaticData", menuName = "StaticData/Screen")]
    public class ScreenStaticData : ScriptableObject
    {
        public List<ScreensConfig> ScreenConfigs;
    }
}