using System.Collections.Generic;
using System.Linq;
using DM = AQR.DomainModels;
using DE = AQR.DataEntities;
using System;

namespace AQR.DataMapper
{
    public static class ReverseMapper
    {
        public static IEnumerable<DE.tblUser> Map(IEnumerable<DM.User> user)
        {
            return user.Select(Map).ToList();
        }

        public static DE.tblUser Map(DM.User user)
        {
            return new DE.tblUser
            {
                UserId = user.UserId,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                Password = user.Password,
                City = user.City,
                Gender = user.Gender,
                //Department = new DE.Department
                //{
                //    DepartmentID = user.Department.DepartmentId,
                //    Name = user.Department.DepartmentName
                //},
                LastModifiedOn = DateTime.Now,
                LastModifiedBy = "TestUser",
                IsDeleted = false

            };
        }
    }
}
