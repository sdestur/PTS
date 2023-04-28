using Entity.Concrete;
using Entity.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEmployeeDal : IEntityRepository<Employee>
    {
        List<EmployeeGetAllDto> GetAllEmploye();
        EmployeeUpdateDto EmployeeUpdate(int id);
        EmployeeGetByIdDto GetById(int id);
    }
}
