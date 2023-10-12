using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EnemySearchScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private TextMeshProUGUI _enemyNameText;
        [SerializeField] private RawImage _enemyIcon;

        public void SetProgressInfo(string playerName, string coins, string enemyName, Texture2D enemyIcon)
        {
            _playerNameText.text = playerName;
            _coinsText.text = coins;
            _enemyNameText.text = enemyName;
            _enemyIcon.texture = enemyIcon;
        }
    }
}