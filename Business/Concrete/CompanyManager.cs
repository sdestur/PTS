using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        IBranchDal _branchDal;
        IDepartmentDal _departmentDal;
        IMissionDal _missionDal;
        IEmployeeDal _employeeDal;
        public CompanyManager(ICompanyDal companyDal, IBranchDal branchDal, IDepartmentDal departmentDal, IMissionDal missionDal, IEmployeeDal employeeDal)
        {
            _companyDal = companyDal;
            _branchDal = branchDal;
            _departmentDal = departmentDal;
            _missionDal = missionDal;
            _employeeDal = employeeDal;
        }
        public IResult Add(CompanyAddRequestDto model)
        {
            var company = new Company
            {
                CompanyName = model.CompanyName,
            };
            _companyDal.Add(company);
            return new SuccessResult(Messages.CompanyAdded);
        }
        
        public IResult Delete(int id)
        {
            var company = _companyDal.Get(x => x.Id == id);
            var branches = _branchDal.GetAll(x => x.CompanyId == id);
            var department = _departmentDal.GetAll(x => x.Branch.CompanyId == id);
            var mission = _missionDal.GetAll(x => x.Department.Branch.CompanyId == id);
            var employee =_employeeDal.GetAll(x=>x.Mission.Department.Branch.CompanyId==id);
            if (company != null)
            {
                
                foreach (var b in branches)
                {
                    foreach (var d in department)
                    {
                        foreach (var m in mission)
                        {
                            foreach(var e in employee)
                            {
                                e.EndDate = DateTime.Now;
                                _employeeDal.Delete(e);
                            }
                           
                            _missionDal.Delete(m);
                        }
                        
                        _departmentDal.Delete(d);
                    }
                    
                    _branchDal.Delete(b);
                }
                _companyDal.Delete(company);
                return new SuccessResult(Messages.CompanyDeleted);
            }
            return new ErrorResult(Messages.Not);
        }

        public IDataResult<List<CompanyDto>> GetAll()
        {
            var company = _companyDal.GetAllCompany();
            return new SuccessDataResult<List<CompanyDto>>(company, Messages.CompaniesListed);
        }

        public IDataResult<CompanyGetByIdDto> GetById(int id)
        {

            var company = _companyDal.GetByIdCompany(id);

            if (company != null)
            {
                return new SuccessDataResult<CompanyGetByIdDto>(company, Messages.CompanyListed);
            }

            return new ErrorDataResult<CompanyGetByIdDto>(Messages.CompanyNotExist);


        }

        public IResult Update(CompanyUpdateRequestDto model)
        {
            var company = _companyDal.Get(x=>x.Id==model.CompanyId);
            if (company != null)
            {
                company.CompanyName = model.CompnayName;
                _companyDal.Update(company);
                return new SuccessResult(Messages.CompanyUpdated);
            }
            return new ErrorResult(Messages.Not);
        }
    }
}
