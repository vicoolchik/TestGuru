using AutoMapper;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Contracts.Requests;

namespace TestGuru.TestService.Api.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<SingleChoiceQuestionRequest, SingleChoiceQuestion>();
            CreateMap<TestRequest, Test>();
            CreateMap<AnswerRequest, Answer>();
            CreateMap<CategoryRequest, Category>();
            CreateMap<TestCollectionRequest, TestCollection>();
        }
    }
}
