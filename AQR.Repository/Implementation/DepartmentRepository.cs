using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.DataEntities;
using System.Data.Entity;

namespace AQR.Repository
{
    public class DepartmentRepository : GenericRepository<AQR_TestEntities, Department>, IDepartmentRepository
    {
        public Department GetById(int id)
        {
           return base.FindBy(x => x.DepartmentID == id).FirstOrDefault();
        }
    }
}
