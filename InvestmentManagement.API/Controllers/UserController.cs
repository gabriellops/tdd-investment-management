using AutoMapper;
using InvestmentManagement.Domain.Contracts.Requests;
using InvestmentManagement.Domain.Contracts.Responses;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserEntity, UserRequest, UserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper) : base(userService, mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public override async Task<ActionResult> PostAsync([FromBody] UserRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);

            await _userService.CreateUserAsync(entity);

            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        [HttpGet("companyName")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<UserResponse>>> GetAsync([FromQuery] string companyName)
        {
            var entities = await _userService.GetAllAsync(x => x.CompanyName.Contains(companyName));

            var response = _mapper.Map<List<UserResponse>>(entities);

            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public override async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] UserRequest request)
        {
            var entity = _mapper.Map<UserEntity>(request);
            entity.Id = id;

            await _userService.UpdateUserAsync(entity);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public override async Task<ActionResult<UserResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _userService.GetByIdUserAsync(id);

            return Ok(_mapper.Map<UserResponse>(entity));
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public override async Task<ActionResult<List<UserResponse>>> GetAsync()
        {
            var entity = await _userService.GetAllUsersAsync();

            return Ok(_mapper.Map<List<UserResponse>>(entity));
        }
    }
}
