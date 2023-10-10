using System;

namespace Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;

        public PlayerProgress()
        {
            WorldData = new WorldData();
        }
    }
}