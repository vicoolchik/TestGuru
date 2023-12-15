using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

public class GetSingleChoiceQuestionsByCategoryIdHandler : IRequestHandler<GetSingleChoiceQuestionsByCategoryIdQuery, IEnumerable<SingleChoiceQuestionResponse>>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetSingleChoiceQuestionsByCategoryIdHandler(ISingleChoiceQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SingleChoiceQuestionResponse>> Handle(GetSingleChoiceQuestionsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var questions = await _questionRepository.GetByCategoryIdAsync(request.CategoryId);
        return _mapper.Map<IEnumerable<SingleChoiceQuestionResponse>>(questions);
    }
}
