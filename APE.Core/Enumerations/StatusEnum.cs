using System.ComponentModel;

namespace APE.Core.Enumerations
{
    public enum StatusEnum
    {
        [Description("Ready")]
        Ready,

        [Description("In-Progress")]
        InProgress,

        [Description("Complete")]
        Complete,

        [Description("Not Started")]
        NotStarted,

        [Description("Failed")]
        Failed,
    }
}
