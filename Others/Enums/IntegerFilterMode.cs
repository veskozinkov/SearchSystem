using System.ComponentModel;

public enum IntegerFilterMode
{
    [Description("=")]
    EXACT,

    [Description("<")]
    LESS_THAN,

    [Description(">")]
    GREATER_THAN
}