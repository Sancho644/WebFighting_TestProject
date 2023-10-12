using System;
using UI.Screens;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;
        [SerializeField] private EnemyFight _enemyFight;

        private void Start()
        {
            _enemyHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _enemyHealth.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_enemyHealth.Current <= 0)
                Die();
        }

        private void Die()
        {
            _enemyFight.OnEnemyDeath();
        }
    }
}