using APE.Core.Implementation;
using APE.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APE.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
