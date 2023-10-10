using System;
using UI.Screens;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class ScreenParent
    {
        public ScreenId ScreenId;
        public Transform Parent;
    }
}