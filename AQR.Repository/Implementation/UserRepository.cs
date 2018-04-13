using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.DataEntities;
using System.Data.Entity;

namespace AQR.Repository
{
    public class UserRepository : GenericRepository<AQR_TestEntities, User>, IUserRepository
    {
        public User GetById(int id)
        {
            return base.FindBy(x => x.UserId == id).FirstOrDefault();
        }

        public void DeleteUser(User user)
        {
            user.IsDeleted = true;
            base.Edit(user);
        }
        public IEnumerable<User> GetAllActiveUsers()
        {
            return base.GetAll().Where(x => x.IsDeleted == false).ToList();
        }
    }
}
