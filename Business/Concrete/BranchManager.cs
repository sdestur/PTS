using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        IBranchDal _branchDal;
        ICompanyDal _companyDal;
        IDepartmentDal _departmentDal;
        IMissionDal _missionDal;
        IEmployeeDal _employeeDal;

        public BranchManager(IBranchDal branchDal, ICompanyDal companyDal, IDepartmentDal departmentDal, IMissionDal missionDal, IEmployeeDal employeeDal)
        {
            _branchDal = branchDal;
            _companyDal = companyDal;
            _departmentDal = departmentDal;
            _missionDal = missionDal;
            _employeeDal = employeeDal;
        }
        public IResult Add(BranchAddRequestDto model)
        {
            var company = _companyDal.Get(x => x.Id == model.CompanyId);
            if (company != null )
            {
                var branch = new Branch();
                branch.BranchName = model.BranchName;
                branch.CompanyId = model.CompanyId;
                _branchDal.Add(branch);
                return new SuccessResult(Messages.BranchAdded);
            }
            return new ErrorResult(Messages.Not);
        }

        public IResult Delete(int id)
        {
            
            var branch = _branchDal.Get(x => x.Id == id);
            var departments = _departmentDal.GetAll(x => x.BranchId == id);
            var mission = _missionDal.GetAll(x => x.Department.Branch.CompanyId == id);
            var employee = _employeeDal.GetAll(x => x.Mission.Department.Branch.CompanyId == id);
            if (branch != null)
            {
                
                foreach (var d in departments)
                {
                    foreach (var m in mission)
                    {
                        foreach (var e in employee)
                        {
                            e.EndDate = DateTime.Now;
                            _employeeDal.Delete(e);
                        }
                        
                        _missionDal.Delete(m);
                    }
                   
                    _departmentDal.Delete(d);
                }
                _branchDal.Delete(branch);
                return new SuccessResult(Messages.BranchDeleted);
            }
            return new ErrorResult(Messages.Not);
        }

        public IDataResult<List<BranchGetAllDto>> GetAll()
        {

            var branch = _branchDal.GetAllBranches();
            return new SuccessDataResult<List<BranchGetAllDto>>(branch, Messages.BranchesListed);

        }
        //çalışmıyor dikkat et
        public IDataResult<List<BranchGetAllDto>> GetAllQ()
        {
            var branch = _branchDal.GetAllBranchesQ().IgnoreQueryFilters().ToList();

            return new SuccessDataResult<List<BranchGetAllDto>>(branch, Messages.BranchesListed);
        }


        public IDataResult<BranchGetByIdDto> GetById(int id)
        {
            var branch = _branchDal.GetByIdBranch(id);
            if (branch != null)
            {
                return new SuccessDataResult<BranchGetByIdDto>(branch, Messages.BranchListed);
            }
            return new ErrorDataResult<BranchGetByIdDto>(Messages.BranchNotExist);
        }

        public IResult Update(BranchUpdateRequestDto model)
        {
            var branch = _branchDal.Get(b => b.Id == model.BranchId);
            if (branch != null)
            {
                branch.BranchName = model.BranchName;
                _branchDal.Update(branch);
                return new SuccessResult(Messages.BranchUpdated);
            }
            return new ErrorResult(Messages.Not);
        }
    }
}
