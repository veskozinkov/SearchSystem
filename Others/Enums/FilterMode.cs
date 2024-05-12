using SearchSystem.Others.Helpers;
using System.ComponentModel;

public enum FilterMode
{
    [Description("=")]
    [FilterModeDescription("Exactly")]
    EXACT,

    [Description("<")]
    [FilterModeDescription("Below")]
    LESS_THAN,

    [Description(">")]
    [FilterModeDescription("Above")]
    GREATER_THAN
}