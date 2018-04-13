using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.Repository;
using DM = AQR.DomainModels;
using DE = AQR.DataEntities;
using AutoMapper;

namespace AQR.BusinessLayer
{
    public class UserService : IUserService
    {
        private IUserRepository userRepo;

        public UserService(IUserRepository _userRepo)
        {
            userRepo = _userRepo;
        }

        public IEnumerable<DM.User> GetAllUsers()
        {
            return Mapper.Map<IEnumerable<DM.User>>(userRepo.GetAllActiveUsers());
        }

        public DM.User GetUser(int id)
        {
            return Mapper.Map<DM.User>(userRepo.GetById(id));
        }

        public DM.User ValidateCredentials(string username, string password)
        {
            var user = userRepo.FindBy(x => x.UserFirstName == username && x.Password == password).FirstOrDefault();

            if (user != null)
                return Mapper.Map<DM.User>(user);
            else
                return null;
        }

        public void Add(DM.User user)
        {
            userRepo.Add(Mapper.Map<DE.User>(user));
        }

        public void Edit(DM.User user)
        {

            userRepo.Edit(Mapper.Map<DE.User>(user));
        }

        public void Delete(DM.User user)
        {
            userRepo.Delete(Mapper.Map<DE.User>(user));
        }
    }
}
