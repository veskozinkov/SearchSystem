using System.ComponentModel;

public enum FilterMode
{
    [Description("=")]
    EXACT,

    [Description("<")]
    LESS_THAN,

    [Description(">")]
    GREATER_THAN
}