using APE.Core.Implementations;
using APE.Core.Interfaces;
using APE.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Interfaces
{
    public interface IProtocolRepository : IRepository<Protocol>
    {
        //Task<IEnumerable<IProtocol>> GetProtocolsAsync();
        //Task<IProtocol> GetProtocolByIdAsync(int protocolId);
        //Task<IEnumerable<IProtocolStep>> GetProtocolStepsAsync(int protocolId);
    }
}