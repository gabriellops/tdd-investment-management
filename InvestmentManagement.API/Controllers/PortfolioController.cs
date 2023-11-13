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
    public class PortfolioController : BaseController<PortfolioEntity, PortfolioRequest, PortfolioResponse>
    {
        public PortfolioController(IBaseService<PortfolioEntity> baseService, IMapper mapper) : base(baseService, mapper)
        {
        }
    }
}