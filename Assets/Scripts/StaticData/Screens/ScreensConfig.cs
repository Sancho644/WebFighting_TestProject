using System;
using UI.Screens;

namespace StaticData.Screens
{
    [Serializable]
    public class ScreensConfig
    {
        public ScreenId ScreenId;
        public ScreenBase Prefab;
    }
}