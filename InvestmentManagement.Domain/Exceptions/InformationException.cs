using InvestmentManagement.Domain.Enums;
using InvestmentManagement.Domain.Utils;

namespace InvestmentManagement.Domain.Exceptions
{
    public class InformationException : Exception
    {
        public InformationException(EStatusExceptionEnum status, List<string> messages, Exception exception = null)
            : base(status.Description(), exception)
        {
            Code = status;
            Messages = messages;
        }

        public InformationException(EStatusExceptionEnum status, string messages, Exception exception = null)
            : base(status.Description(), exception)
        {
            Code = status;
            Messages = new List<string> { messages };
        }


        public EStatusExceptionEnum Code { get; }

        public List<string> Messages { get; }
    }
}
