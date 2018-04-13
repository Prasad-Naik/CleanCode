using AQR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.DomainModels;

namespace AQR.BusinessLayer
{
    public interface IDepartmentService 
    {
         IEnumerable<Department> GetAllDepartments();

         Department GetDepartment(int id);
    }
}
