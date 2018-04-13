using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AQR.DataEntities ;

namespace AQR.Repository
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        Department GetById(int id);
    }
}
