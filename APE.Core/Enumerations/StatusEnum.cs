using System.ComponentModel;

namespace APE.Core.Enumerations
{
    public enum StatusEnum
    {
        [Description("Ready")]
        Ready,

        [Description("Busy")]
        Busy,

        [Description("Complete")]
        Complete,

        [Description("In-Progress")]
        InProgress,

        [Description("Not Started")]
        NotStarted,
    }
}
