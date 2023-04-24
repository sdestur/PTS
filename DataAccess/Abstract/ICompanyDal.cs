using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        List<CompanyDto> GetAllCompany();
        CompanyGetByIdDto GetByIdCompany(int id);
    }
}
