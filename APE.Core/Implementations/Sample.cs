using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class Sample : ISample
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public SampleTypeEnum SampleType { get; set; }
    }
}
