using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfCompanyDal : EfEntityRepositoryBase<Company, PersonelTakipSistemiContext>, ICompanyDal
    {
        public List<CompanyDto> GetAllCompany()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from company in context.Companys
                            //where company.IsDeleted == false
                            select new CompanyDto
                            {
                                CompanyName = company.CompanyName,
                            };
                return query.ToList();


            }
        }

        public CompanyGetByIdDto GetByIdCompany(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from company in context.Companys
                            where company.Id == id 
                            select new CompanyGetByIdDto
                            {
                                CompanyName = company.CompanyName,
                            };
               return query.FirstOrDefault();


            }
        }

        //private IUnitOfWork _unitOfWork;
        //public EfCompanyDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

    }
}
