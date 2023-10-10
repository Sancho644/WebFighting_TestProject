using System;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        public PlayerData PlayerData;
        public LootData LootData;

        public WorldData()
        {
            PlayerData = new PlayerData();
            LootData = new LootData();
        }
    }
}