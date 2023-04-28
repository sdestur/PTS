using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IResult Add(BranchAddRequestDto model);
        IResult Delete(int id);
        IResult Update(BranchUpdateRequestDto model);
        IDataResult<List<BranchGetAllDto>> GetAll();
        IDataResult<List<BranchGetAllDto>> GetAllQ();
        IDataResult<BranchGetByIdDto> GetById(int ıd);
    }
}
