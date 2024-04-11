using System.ComponentModel;

namespace InvestmentManagement.Domain.Enums
{
    public enum EStatusExceptionEnum
    {
        [Description("None")]
        None = 0,
        [Description("An unexpected error occurred")]
        Error = 1,
        [Description("Data not found")]
        NotFound = 2,
        [Description("Unauthorized access")]
        Unauthorized = 3,
        [Description("Mandatory field(s) not provided")]
        MandatoryFields = 4,
        [Description("Incorrect format for field(s)")]
        IncorrectFormat = 5,
        [Description("Data not processed")]
        NotProcessed = 6,
        [Description("Forbidden access")]
        ForbiddenAccess = 7
    }
}
