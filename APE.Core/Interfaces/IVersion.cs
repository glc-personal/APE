namespace APE.Core.Interfaces
{
    public interface IVersion
    {
        int MajorNumber { get; set;}
        int MinorNumber { get; set;}
        int RevisionNumber { get; set;}
        string Build { get; set;}
    }
}
