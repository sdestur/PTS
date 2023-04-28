using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IResult Add(EmployeeAddRequestDto model);
        IResult Delete(int id);
        IResult Update(EmployeeRequestDto model);
        IDataResult<List<EmployeeGetAllDto>> GetAll();
        IDataResult<EmployeeGetByIdDto> GetById(int id);
    }
}
