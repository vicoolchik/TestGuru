﻿using AutoMapper;
using TestGuruApi.Entities.DbSet;
using TestGuruApi.Entities.Dto.Responses;

namespace TestGuruApi.TestService.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));
            CreateMap<Test, TestResponse>();
            CreateMap<Answer, AnswerResponse>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
