using System.ComponentModel;

namespace SearchSystem.Others.Enums.Job;

public enum JobPaidLeave
{
    [Description("20-25 Days")]
    BETWEEN_20_AND_25_DAYS,

    [Description("25-30 Days")]
    BETWEEN_25_AND_30_DAYS,

    [Description("30+ Days")]
    MORE_THAN_30_DAYS
}