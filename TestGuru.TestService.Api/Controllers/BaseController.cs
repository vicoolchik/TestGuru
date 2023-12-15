using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestGuru.TestService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public BaseController( IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
    }
}
