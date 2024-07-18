using APE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Interfaces
{
    public interface IProtocolService
    {
        Task<IEnumerable<IProtocol>> GetProtocolsAsync();
        Task<IProtocol> GetProtocolByIdAsync(int protocolId);
        Task<IEnumerable<IProtocolStep>> GetProtocolStepsAsync(int protocolId);
    }
}
