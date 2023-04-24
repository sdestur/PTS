using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;
        public BranchManager(IBranchDal branchDal)
        {
            _branchDal = branchDal;
        }
        public IResult Add(BranchAddRequestDto model)
        {
            var branch = new Branch();
            branch.BranchName = model.BranchName;
            branch.CompanyId = 1;
            _branchDal.Add(branch);
            return new SuccessResult(Messages.BranchAdded);
        }

        public IResult Delete(int id)
        {
            var branch = _branchDal.Get(x=>x.Id == id);
            branch.IsDeleted = true;
            _branchDal.Update(branch);
            return new SuccessResult(Messages.BranchDeleted);
        }

        public IDataResult<List<BranchGetAllDto>> GetAll()
        {
            var result=_branchDal.GetAllBranches();

            return new SuccessDataResult<List<BranchGetAllDto>>(result,Messages.BranchesListed);
        }
        public IDataResult<IQueryable<BranchGetAllDto>> GetAllQ()
        {
            var result = _branchDal.GetAllBranchesQ();

            return new SuccessDataResult<IQueryable<BranchGetAllDto>>(result, Messages.BranchesListed);
        }

        //GetById ve GetAll da istek atınca ekstra yerler görünüyor neden ve nasıl düzeltilir.Anlamadıysan Swaggerdan dene
        public IDataResult<Branch> GetById(int id)
        {
            var branch = new Branch();
            if (branch.Id == id)
            {
                return new SuccessDataResult<Branch>(_branchDal.Get(x => x.Id == id), Messages.BranchListed);
            }
            return new ErrorDataResult<Branch>(Messages.BranchNotExist);
        }

        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(Messages.BranchUpdated);
        }

    }
}
