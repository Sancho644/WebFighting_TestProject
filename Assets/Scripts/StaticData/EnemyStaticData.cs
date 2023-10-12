using Enemy;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyId EnemyId;

        public int MaxHp = 100;
        public int MinHp = 50;

        public int MaxDamage = 5;
        public int MinDamage = 10;

        public int MaxReward = 100;
        public int MinReward = 1000;
    }
}