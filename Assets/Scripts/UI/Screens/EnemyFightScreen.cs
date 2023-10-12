using TMPro;
using UnityEngine;

namespace UI.Screens
{
    public class EnemyFightScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _enemyName;

        public void SetEnemyName(string enemyName)
        {
            _enemyName.text = enemyName;
        }
    }
}