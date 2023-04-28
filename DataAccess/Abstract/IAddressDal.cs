using Entity.Concrete;
using Entity.DTOs.AddressDtos;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAddressDal : IEntityRepository<Address>
    {
        AddressGetByIdDto GetByIdAddress(int id);
    }
}
