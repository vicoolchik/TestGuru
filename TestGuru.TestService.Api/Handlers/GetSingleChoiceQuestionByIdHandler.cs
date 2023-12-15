using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

public class GetSingleChoiceQuestionByIdHandler : IRequestHandler<GetSingleChoiceQuestionByIdQuery, SingleChoiceQuestionResponse>
{
    private readonly ISingleChoiceQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetSingleChoiceQuestionByIdHandler(ISingleChoiceQuestionRepository questionRepository, IMapper mapper)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
    }

    public async Task<SingleChoiceQuestionResponse> Handle(GetSingleChoiceQuestionByIdQuery request, CancellationToken cancellationToken)
    {
        var question = await _questionRepository.GetById(request.Id);
        return question != null ? _mapper.Map<SingleChoiceQuestionResponse>(question) : null;
    }
}
