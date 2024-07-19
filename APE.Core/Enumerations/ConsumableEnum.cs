using System.ComponentModel;

namespace APE.Core.Enumerations
{
    public enum ConsumableEnum
    {
        [Description("Tip Box")]
        TipBox,

        [Description("Assay Strip")]
        AssayStrip,

        [Description("Quant Strip")]
        QuantStrip,

        [Description("Heater/Shaker")]
        HeaterShaker,

        [Description("Chiller")]
        Chiller,

        [Description("Reagent Cartridge")]
        ReagentCartridge,

        [Description("Mag Separator")]
        MagSeparator,
    }
}
