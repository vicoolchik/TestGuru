namespace TestGuruApi.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ITestRepository Tests { get; }
        ICategoryRepository Categories { get; }
        ISingleChoiceQuestionRepository SingleChoiceQuestions { get; }
        IMultipleChoiceQuestionRepository MultipleChoiceQuestions { get; }
        IMatchingQuestionRepository MatchingQuestions { get; }
        IAnswerRepository Answers { get; }
        ITestCollectionRepository TestCollections { get; }

        Task<bool> CompleteAsync();
    }
}
