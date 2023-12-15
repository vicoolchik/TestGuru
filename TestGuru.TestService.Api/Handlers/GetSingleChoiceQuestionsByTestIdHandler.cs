using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

public class GetSingleChoiceQuestionsByTestIdHandler : IRequestHandler<GetSingleChoiceQuestionsByTestIdQuery, IEnumerable<SingleChoiceQuestionResponse>>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetSingleChoiceQuestionsByTestIdHandler(ISingleChoiceQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SingleChoiceQuestionResponse>> Handle(GetSingleChoiceQuestionsByTestIdQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetByTestIdAsync(request.TestId);
        return _mapper.Map<IEnumerable<SingleChoiceQuestionResponse>>(questions);
    }
}
