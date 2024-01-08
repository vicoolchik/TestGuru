using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface ITestAttemptRepository : IGenericRepository<TestAttempt>
    {
        Task StartAttempt(Guid attemptId);
        Task<bool> EndAttempt(Guid attemptId);
        Task<bool> PauseAttempt(Guid attemptId);
        Task<bool> ResumeAttempt(Guid attemptId);
        Task<bool> SubmitResponse(Guid attemptId, Guid questionId, Answer answer);
        Task<float> CalculateScore(Guid attemptId);
        Task<bool> IsTimeExceeded(Guid attemptId);
    }
}
