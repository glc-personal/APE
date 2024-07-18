using APE.Core.Enumerations;

namespace APE.Core.Interfaces
{
    public interface IProtocolStep
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        StatusEnum Status { get; set; }
    }
}
