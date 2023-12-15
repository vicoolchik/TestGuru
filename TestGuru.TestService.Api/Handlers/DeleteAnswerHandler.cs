using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

public class DeleteAnswerHandler : IRequestHandler<DeleteAnswerCommand, Unit>
{
    private readonly IAnswerRepository _answerRepository;

    public DeleteAnswerHandler(IAnswerRepository answerRepository)
    {
        _answerRepository = answerRepository;
    }

    public async Task<Unit> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        var success = await _answerRepository.Delete(request.Id);
        if (!success)
        {
            throw new KeyNotFoundException("Answer not found");
        }

        return Unit.Value;
    }
}
