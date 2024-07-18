namespace APE.Core.Interfaces
{
    public interface IAddSampleProtocolStep : IProtocolStep
    {
        int SampleVolume { get; set; }
        ITip Tip { get; set; }
    }
}
