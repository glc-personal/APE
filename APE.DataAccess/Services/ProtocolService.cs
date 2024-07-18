using APE.Core.Interfaces;
using APE.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Services
{
    public class ProtocolService : IProtocolService
    {
        private readonly IProtocolRepository _protocolRepository;

        public ProtocolService(IProtocolRepository protocolRepository)
        {
            _protocolRepository = protocolRepository;
        }

        public async Task<IEnumerable<IProtocol>> GetProtocolsAsync() =>
            await _protocolRepository.GetProtocolsAsync();

        public async Task<IProtocol> GetProtocolByIdAsync(int protocolId) =>
            await _protocolRepository.GetProtocolByIdAsync(protocolId);

        public async Task<IEnumerable<IProtocolStep>> GetProtocolStepsAsync(int protocolId) =>
            await _protocolRepository.GetProtocolStepsAsync(protocolId);
    }
}
