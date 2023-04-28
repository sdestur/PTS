using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDepartmentDal : IEntityRepository<Department>
    {
        List<DepartmentGetAllDto> GetAllDepartmen();
        DepartmentGetByIdDto GetByIdDepartmen(int id);
        //void Add(DepartmentAddRequestDto model);
    }
}
