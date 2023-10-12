using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image _imageCurrent;
        [SerializeField] private Image _imageDamaged;
        [SerializeField] private float _animationSpeed;

        public void SetValue(float current, float max)
        {
            _imageCurrent.fillAmount = current / max;

            StartCoroutine(StartAnimation(current, max));
        }

        private IEnumerator StartAnimation(float current, float max)
        {
            float lerpTimer = Time.deltaTime;
            float percentComplete = lerpTimer / _animationSpeed;

            while (_imageDamaged.fillAmount > current / max)
            {
                _imageDamaged.fillAmount = Mathf.Lerp(_imageDamaged.fillAmount, current / max, percentComplete);

                yield return null;
            }

            yield return null;
        }
    }
}