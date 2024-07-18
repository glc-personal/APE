using APE.Core.Enumerations;
using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class ProtocolStepBase : IProtocolStep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StatusEnum Status { get; set; }
        public ISample Sample { get; set; }
    }
}
