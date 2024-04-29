using System.ComponentModel;

namespace SearchSystem.Others.Enums.Job;

public enum JobPosition
{
    [Description("Management")]
    MANAGEMENT,

    [Description("Expert / Specialist")]
    EXPERT_SPECIALIST,

    [Description("Employee / Worker")]
    EMPLOYEE_WORKER
}