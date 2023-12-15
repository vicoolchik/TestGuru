using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Commands;

public class UpdateSingleChoiceQuestionHandler : IRequestHandler<UpdateSingleChoiceQuestionCommand, Unit>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public UpdateSingleChoiceQuestionHandler(ISingleChoiceQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetById(request.Id);
        if (question == null)
        {
            throw new KeyNotFoundException("Question not found");
        }

        _mapper.Map(request.QuestionRequest, question);
        await _questionRepository.Update(question);

        return Unit.Value;
    }
}
