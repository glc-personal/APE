using APE.Core.Implementation;
using APE.Core.Interfaces;
using APE.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
