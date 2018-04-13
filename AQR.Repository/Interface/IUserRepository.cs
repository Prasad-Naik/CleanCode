using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.DataEntities ;

namespace AQR.Repository
{
   public interface IUserRepository : IGenericRepository<User>
    {
       User GetById(int id);

       void DeleteUser(User user);

       IEnumerable<User> GetAllActiveUsers();
    }
}
