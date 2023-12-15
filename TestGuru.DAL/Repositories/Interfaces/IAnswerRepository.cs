using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetAllByQuestionIdAsync(Guid questionId);
    }
}
