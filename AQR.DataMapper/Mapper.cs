using System.Collections.Generic;
using System.Linq;
using DM = AQR.DomainModels;
using DE = AQR.DataEntities;

namespace AQR.DataMapper
{
    public static class Mapper1
    {
        public static IEnumerable<DM.User> Map(IEnumerable<DE.tblUser> user)
        {
            return user.Select(Map).ToList();
        }

        public static DM.User Map(DE.tblUser user)
        {
            return new DM.User
            {
                UserId = user.UserId,
                FirstName = user.UserFirstName,
                LastName = user.UserLastName,
                Password = user.Password,
                City = user.City,
                Gender = user.Gender,
                Department = new DM.Department
                {
                    DepartmentId = user.Department.DepartmentID,
                    DepartmentName = user.Department.Name
                }
            };
        }

        public static IEnumerable<DM.Department> Map(IEnumerable<DE.Department> department)
        {
            return department.Select(Map).ToList();
        }
        public static DM.Department Map(DE.Department department)
        {
            return new DM.Department
            {
                DepartmentId = department.DepartmentID,
                DepartmentName = department.Name
            };
        }
    }
}
