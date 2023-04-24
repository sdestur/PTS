using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDepartmentService
    {
        IResult Add(DepartmentAddRequestDto model);
        IResult Delete(Department department);
        IResult Update(Department department);
        IDataResult<List<Department>> GetAll();
        IDataResult<Department> GetById(int ıd);
    }
}
