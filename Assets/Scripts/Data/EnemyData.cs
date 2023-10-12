using System;

namespace Data
{
    [Serializable]
    public class EnemyData
    {
        public string EnemyName;

        public void SetName(string name)
        {
            EnemyName = name;
        }
    }
}