using APE.Core.Implementation;
using APE.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(APEContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllUsersAsync() =>
            await _context.Users.ToListAsync();
    }
}
