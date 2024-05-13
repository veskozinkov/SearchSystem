using System.ComponentModel;

public enum CarFuel
{
    [Description("Petrol")]
    PETROL,

    [Description("Diesel")]
    DIESEL,

    [Description("Electric")]
    ELECTRIC,

    [Description("Hybrid")]
    HYBRID,

    [Description("Plug-in hybrid")]
    PLUG_IN_HYBRID
}