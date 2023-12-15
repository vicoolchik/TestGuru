using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

public class DeleteSingleChoiceQuestionHandler : IRequestHandler<DeleteSingleChoiceQuestionCommand, Unit>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;

    public DeleteSingleChoiceQuestionHandler(ISingleChoiceQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<Unit> Handle(DeleteSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
    {
        var success = await _questionRepository.Delete(request.Id);
        if (!success)
        {
            throw new KeyNotFoundException("Question not found");
        }

        return Unit.Value;
    }
}
