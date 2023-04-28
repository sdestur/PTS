using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IResult Add(CompanyAddRequestDto model);
        IResult Delete(int id);
        IResult Update(CompanyUpdateRequestDto model);
        IDataResult<List<CompanyDto>> GetAll();
        IDataResult<CompanyGetByIdDto> GetById(int ıd);
    }
}
