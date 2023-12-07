using TestGuruApi.Entities.DbSet;

public interface IQuestionRepository<TQuestion> where TQuestion : Question
{
    Task<IEnumerable<TQuestion>> GetByTestIdAsync(Guid testId);
    Task<IEnumerable<TQuestion>> GetByCategoryIdAsync(Guid categoryId);
}
