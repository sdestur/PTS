using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfBranchDal : EfEntityRepositoryBase<Branch, PersonelTakipSistemiContext>, IBranchDal
    {
        public IQueryable<BranchGetAllDto> GetAllBranchesQ()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from branch in context.Branches
                            join company in context.Companys
                            on branch.CompanyId equals company.Id
                            where branch.IsDeleted == false
                            select new BranchGetAllDto
                            {
                                BranchName = branch.BranchName,
                                CompanyName = company.CompanyName,
                            };
                return query;
                            

            }
        }
        public List<BranchGetAllDto> GetAllBranches()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from branch in context.Branches
                            join company in context.Companys
                            on branch.CompanyId equals company.Id
                            select new BranchGetAllDto
                            {
                                BranchName = branch.BranchName,
                                CompanyName = company.CompanyName,
                            };
                return query.ToList();


            }
        }


    };
}
