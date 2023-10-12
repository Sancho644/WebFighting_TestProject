using System;

namespace Data
{
    [Serializable]
    public class WorldData
    {
        public PlayerData PlayerData;
        public EnemyData EnemyData;
        public LootData LootData;

        public WorldData()
        {
            PlayerData = new PlayerData();
            LootData = new LootData();
            EnemyData = new EnemyData();
        }
    }
}