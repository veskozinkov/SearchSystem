using System.ComponentModel;

namespace SearchSystem.Others.Enums.Job;

public enum JobEmployment
{
    [Description("Permanent")]
    PERMANENT,

    [Description("Temporary / Seasonal")]
    TEMPORARY_SEASONAL,

    [Description("Internship")]
    INTERNSHIP,

    [Description("Freelance")]
    FREELANCE,

    [Description("Full-time")]
    FULL_TIME,

    [Description("Part-time")]
    PART_TIME,

    [Description("Flexible working hours")]
    FLEXIBLE_WORKING_HOURS,

    [Description("For students")]
    FOR_STUDENTS,

    [Description("With refugee status")]
    WITH_REFUGEE_STATUS
}