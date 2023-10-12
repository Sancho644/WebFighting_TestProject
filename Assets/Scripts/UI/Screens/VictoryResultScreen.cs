using TMPro;
using UnityEngine;

namespace UI.Screens
{
    public class VictoryResultScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _enemyName;
        [SerializeField] private TextMeshProUGUI _coinsCount;

        public void SetResultInfo(string enemyName, string coins)
        {
            _enemyName.text = enemyName;
            _coinsCount.text = coins;
        }
    }
}