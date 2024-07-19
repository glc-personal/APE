using APE.Core.Implementation;

namespace APE.Core.Interfaces
{
    public interface IAddSampleProtocolStep : IProtocolStep
    {
        ISample Sample { get; set; }
        int Volume { get; set; }
        ILocation Destination { get; set; }

    }
}
