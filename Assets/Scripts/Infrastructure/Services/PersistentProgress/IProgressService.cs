using Data;

namespace Infrastructure.Services.PersistentProgress
{
    public interface IProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}