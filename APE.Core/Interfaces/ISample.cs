using APE.Core.Enumerations;

namespace APE.Core.Interfaces
{
    public interface ISample
    {
        int Id { get; set; }
        int PatientId { get; set; }
        SampleTypeEnum SampleType { get; set; } // Get LiquidClass from SampleType
    }
}
