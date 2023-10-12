using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IEnemyHealth
    {
        public event Action HealthChanged;

        public float Current { get; set; }
        public float Max { get; set; }

        public void TakeDamage(float damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;

            HealthChanged?.Invoke();
        }
    }
}