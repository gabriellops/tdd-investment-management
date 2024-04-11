using AutoMapper;
using InvestmentManagement.Domain.Contracts.Responses;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Services;
using InvestmentManagement.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(InformationResponse), 400)]
    [ProducesResponseType(typeof(InformationResponse), 401)]
    [ProducesResponseType(typeof(InformationResponse), 403)]
    [ProducesResponseType(typeof(InformationResponse), 404)]
    [ProducesResponseType(typeof(InformationResponse), 500)]
    public class BaseController<TEntity, KRequest, YResponse> : ControllerBase where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntity> _baseService;
        private readonly IMapper _mapper;

        public BaseController(IBaseService<TEntity> baseService, IMapper mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<List<YResponse>>> GetAsync()
        {
            var entities = await _baseService.GetAllAsync();
            var response = _mapper.Map<List<YResponse>>(entities);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public virtual async Task<ActionResult<YResponse>> GetByIdAsync([FromRoute] int id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            var response = _mapper.Map<YResponse>(entity);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public virtual async Task<ActionResult> PostAsync([FromBody] KRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);

            await _baseService.AddAsync(entity);

            return Created(nameof(PostAsync), new { id = entity.Id });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> PutAsync([FromRoute] int id, [FromBody] KRequest request)
        {
            var entity = _mapper.Map<TEntity>(request);
            entity.Id = id;

            await _baseService.UpdateAsync(entity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public virtual async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            await _baseService.DeleteAsync(id);

            return NoContent();
        }
    }
}
