using APE.Core.Interfaces;

namespace APE.Core.Implementation
{
    public class Version : IVersion
    {
        public int MajorNumber { get; set; }
        public int MinorNumber { get; set; }
        public int RevisionNumber { get; set; }
        public string Build { get; set; }
    }
}
