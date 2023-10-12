using Data;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace UI.Screens
{
    public class ScreenBase : MonoBehaviour
    {
        private IProgressService _progressService;

        protected PlayerProgress Progress => _progressService.Progress;

        protected void Construct(IProgressService progressService)
        {
            _progressService = progressService;
        }

        private void Start()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
        }
    }
}