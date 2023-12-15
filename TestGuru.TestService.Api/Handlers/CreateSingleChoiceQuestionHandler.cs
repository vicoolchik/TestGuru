using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Api.Commands;
using TestGuru.TestService.Contracts.Responses;

public class CreateSingleChoiceQuestionHandler : IRequestHandler<CreateSingleChoiceQuestionCommand, SingleChoiceQuestionResponse>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public CreateSingleChoiceQuestionHandler(ISingleChoiceQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<SingleChoiceQuestionResponse> Handle(CreateSingleChoiceQuestionCommand request, CancellationToken cancellationToken)
    {
        var question = _mapper.Map<SingleChoiceQuestion>(request.QuestionRequest);
        await _questionRepository.Add(question);

        return _mapper.Map<SingleChoiceQuestionResponse>(question);
    }
}
