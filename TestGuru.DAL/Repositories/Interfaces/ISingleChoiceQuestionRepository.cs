using TestGuru.Domain.Entities;

namespace TestGuru.DAL.Repositories.Interfaces
{
    public interface ISingleChoiceQuestionRepository : IGenericRepository<SingleChoiceQuestion>, IQuestionRepository<SingleChoiceQuestion>
    {
    }
}
