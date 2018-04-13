using AQR.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM = AQR.DomainModels;
using DE = AQR.DataEntities;
using AutoMapper;

namespace AQR.BusinessLayer
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository departmentRepo;

        public DepartmentService(IDepartmentRepository _departmentRepo)
        {
            departmentRepo = _departmentRepo;
        }

        public IEnumerable<DM.Department> GetAllDepartments()
        {
            return Mapper.Map<IEnumerable<DM.Department>>(departmentRepo.GetAll());
        }

        public DM.Department GetDepartment(int id)
        {
            return Mapper.Map<DM.Department>(departmentRepo.GetById(id));
        }
    }
}
