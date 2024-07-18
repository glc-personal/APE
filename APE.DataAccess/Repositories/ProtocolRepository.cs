using APE.Core.Implementations;
using APE.Core.Interfaces;
using APE.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APE.DataAccess.Repositories
{
    public class ProtocolRepository : Repository<Protocol>, IProtocolRepository
    {
        public ProtocolRepository(APEContext context) : base(context)
        {
        }

        public async Task<IEnumerable<IProtocolStep>> GetProtocolStepsAsync(int protocolId)
        {
            var protocol = await _context.Protocols
                .Include(p => p.Steps) // Assuming Steps is the collection navigation property
                .FirstOrDefaultAsync(p => p.Id == protocolId);

            return protocol?.Steps.ToList(); // Return the steps or an empty list if protocol is null
        }
    }
}
