using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(AddressAddRequestDto model);
        IResult Delete(int id);
        IResult Update(AddressUpdateRequestDto model);
        IDataResult<List<Address>> GetAll();
        IDataResult<AddressGetByIdDto> GetById(int ıd);

    }
}
