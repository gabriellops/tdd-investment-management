using InvestmentManagement.Domain.Enums;
using InvestmentManagement.Domain.Utils;

namespace InvestmentManagement.Domain.Contracts.Responses
{
    public class InformationResponse
    {
        public EStatusExceptionEnum Code { get; set; }
        public string Descricao { get { return Code.Description(); } }
        public List<string> Menssages { get; set; }
        public string Detail { get; set; }
    }
}