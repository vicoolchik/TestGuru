using AutoMapper;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Requests;

namespace TestGuruApi.TestService.MappingProfiles
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
