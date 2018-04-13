using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.Repository;
using AQR.DomainModels;


namespace AQR.BusinessLayer
{
    public interface IUserService 
    {
         IEnumerable<User> GetAllUsers();

         User GetUser(int id);

         User ValidateCredentials(string username, string password);

         void Add(User user);

         void Edit(User user);

         void Delete(User user);
       
    }
}
