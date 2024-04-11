using AutoMapper;
using InvestmentManagement.Domain.Contracts.Requests;
using InvestmentManagement.Domain.Contracts.Responses;
using InvestmentManagement.Domain.Entities;
using InvestmentManagement.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : BaseController<OperationEntity, OperationRequest, OperationResponse>
    {
        public OperationController(IBaseService<OperationEntity> baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}