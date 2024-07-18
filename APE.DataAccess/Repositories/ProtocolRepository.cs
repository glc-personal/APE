using APE.Core.Implementations;
using APE.Core.Interfaces;
using APE.DataAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APE.DataAccess.Repositories
{
    public class ProtocolRepository : Repository<Protocol>, IProtocolRepository
    {
        private readonly IMapper _mapper;

        public ProtocolRepository(APEContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        /*public async Task<IEnumerable<IProtocol>> GetProtocolsAsync()
        {
            var protocols = await _context.Protocols.Include(p => p.Steps).ToListAsync();
            return _mapper.Map<IEnumerable<IProtocol>>(protocols);
        }

        public async Task<IProtocol> GetProtocolByIdAsync(int protocolId)
        {
            var protocol = await _context.Protocols.Include(p => p.Steps).FirstOrDefaultAsync(p => p.Id == protocolId);
            return _mapper.Map<IProtocol>(protocol);
        }

        public async Task<IEnumerable<IProtocolStep>> GetProtocolStepsAsync(int protocolId)
        {
            var protocol = await _context.Protocols
                .Include(p => p.Steps)
                .FirstOrDefaultAsync(p => p.Id == protocolId);

            return _mapper.Map<IEnumerable<IProtocolStep>>(protocol?.Steps);
        }*/
    }
}
