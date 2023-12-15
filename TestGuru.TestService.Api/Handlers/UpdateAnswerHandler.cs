using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

public class UpdateAnswerHandler : IRequestHandler<UpdateAnswerCommand, Unit>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public UpdateAnswerHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
    {
        var answer = await _answerRepository.GetById(request.Id);
        if (answer == null)
        {
            throw new KeyNotFoundException("Answer not found");
        }

        _mapper.Map(request.AnswerRequest, answer);
        await _answerRepository.Update(answer);

        return Unit.Value;
    }
}
