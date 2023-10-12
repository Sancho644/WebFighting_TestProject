using Enemy;
using UnityEngine;

namespace UI.Elements
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HpBar _hpBar;

        private IEnemyHealth _health;

        public void Construct(IEnemyHealth health)
        {
            _health = health;

            _health.HealthChanged += UpdateHpBar;
        }

        private void Start()
        {
            IEnemyHealth health = GetComponent<IEnemyHealth>();

            if (health != null)
                Construct(health);
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= UpdateHpBar;
        }

        private void UpdateHpBar()
        {
            _hpBar.SetValue(_health.Current, _health.Max);
        }
    }
}