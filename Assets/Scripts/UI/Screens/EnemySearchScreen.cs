using System.Collections;
using Infrastructure.Services.PersistentProgress;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace UI.Screens
{
    public class EnemySearchScreen : ScreenBase
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private TextMeshProUGUI _playerNameText;
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Button _enemySearchingButton;
        [SerializeField] private Button _enemyFightButton;
        [Space] 
        [SerializeField] private string _url;

        public void Construct(IProgressService progressService)
        {
            base.Construct(progressService);
        }

        protected override void Initialize()
        {
            RequestEnemyInfo();
            RefreshPlayerNameText();
            RefreshCoinsText();
        }

        private void RequestEnemyInfo()
        {
            _loadingScreen.SetActive(true);
            StartCoroutine(SendRequest());
        }

        private void RefreshPlayerNameText()
        {
            _playerNameText.text = Progress.WorldData.PlayerData.PlayerName;
        }

        private void RefreshCoinsText()
        {
            _coinsText.text = Progress.WorldData.LootData.Collected.ToString();
        }

        private IEnumerator SendRequest()
        {
            UnityWebRequest request = UnityWebRequest.Get(_url);

            yield return request.SendWebRequest();

            _loadingScreen.SetActive(false);
            Debug.Log(request.downloadHandler.text);
        }
    }
}