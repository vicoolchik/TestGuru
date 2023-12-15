using AutoMapper;
using TestGuru.Domain.Entities;
using TestGuru.TestService.Contracts.Responses;

namespace TestGuru.TestService.Api.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<SingleChoiceQuestion, SingleChoiceQuestionResponse>()
                        .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Test, TestResponse>();
            CreateMap<Answer, AnswerResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<TestCollection, TestCollectionResponse>();
        }
    }
}
