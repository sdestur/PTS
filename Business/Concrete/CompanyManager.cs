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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
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
            company.IsDeleted = true;
            _companyDal.Update(company);
            return new SuccessResult(Messages.CompanyDeleted); 
        }

        public IDataResult<List<CompanyDto>> GetAll()
        {
            return new SuccessDataResult<List<CompanyDto>>(_companyDal.GetAllCompany(),Messages.CompaniesListed);
        }

        public IDataResult<CompanyGetByIdDto> GetById(int id)
        {

            var result = _companyDal.GetByIdCompany(id);
           
            if (result != null)
            {
                return new SuccessDataResult<CompanyGetByIdDto>(result, Messages.CompanyListed);
            }
            
            return new ErrorDataResult<CompanyGetByIdDto>( Messages.CompanyNotExist);


        }

        public IResult Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
