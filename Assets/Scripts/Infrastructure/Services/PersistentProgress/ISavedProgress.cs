using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress
    {
        void LoadProgress(PlayerProgress progress);
        void UpdateProgress(PlayerProgress progress);
    }
}