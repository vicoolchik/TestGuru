using AutoMapper;
using MediatR;
using TestGuru.DAL.Repositories.Interfaces;
using TestGuru.TestService.Api.Queries;
using TestGuru.TestService.Contracts.Responses;

public class GetAnswerByIdHandler : IRequestHandler<GetAnswerByIdQuery, AnswerResponse>
{
    private readonly IAnswerRepository _answerRepository;
    private readonly IMapper _mapper;

    public GetAnswerByIdHandler(IAnswerRepository answerRepository, IMapper mapper)
    {
        _answerRepository = answerRepository;
        _mapper = mapper;
    }

    public async Task<AnswerResponse> Handle(GetAnswerByIdQuery request, CancellationToken cancellationToken)
    {
        var answer = await _answerRepository.GetById(request.Id);
        return answer != null ? _mapper.Map<AnswerResponse>(answer) : null;
    }
}
