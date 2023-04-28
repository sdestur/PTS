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
    public interface IBranchDal : IEntityRepository<Branch>
    {
        List<BranchGetAllDto> GetAllBranches();
        IQueryable<BranchGetAllDto> GetAllBranchesQ();
        BranchGetByIdDto GetByIdBranch(int id);
    }
}
