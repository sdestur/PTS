using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CompanyDtos;
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
        IResult Delete(int id);
        IResult Update(DepartmentUpdateRequestDto model);
        IDataResult<List<DepartmentGetAllDto>> GetAll();
        IDataResult<DepartmentGetByIdDto> GetById(int ıd);
    }
}
