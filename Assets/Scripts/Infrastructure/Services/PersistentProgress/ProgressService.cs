using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public class ProgressService : IProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}