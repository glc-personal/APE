using APE.Core.Implementation;
using APE.DataAccess.Entities;
using APE.DataAccess.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(APEContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var userEntities = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<User>>(userEntities);
        }
    }
}
