﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestGuruApi.DataService.Repositories.Interfaces;

namespace TestGuruApi.TestService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
