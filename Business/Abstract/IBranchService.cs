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
        IResult Update(Branch branch);
        IDataResult<List<BranchGetAllDto>> GetAll();
        IDataResult<IQueryable<BranchGetAllDto>> GetAllQ();
        IDataResult<Branch> GetById(int ıd);
    }
}
