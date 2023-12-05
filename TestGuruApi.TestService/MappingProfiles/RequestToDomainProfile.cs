using AutoMapper;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Requests;

namespace TestGuruApi.TestService.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<QuestionRequest, Question>();
            CreateMap<TestRequest, Test>();
            CreateMap<AnswerRequest, Answer>();
            CreateMap<CategoryRequest, Category>();
        }
    }
}
