using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

public class GetAnswersByQuestionHandler : IRequestHandler<GetAnswersByQuestionQuery, IEnumerable<AnswerResponse>>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswersByQuestionHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AnswerResponse>> Handle(GetAnswersByQuestionQuery request, CancellationToken cancellationToken)
    {
        var answers = await _answerRepository.GetAllByQuestionIdAsync(request.QuestionId);
        return _mapper.Map<IEnumerable<AnswerResponse>>(answers);
    }
}
