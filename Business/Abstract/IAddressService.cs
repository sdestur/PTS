using Business.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAddressService
    {
        IResult Add(Address address);
        IResult Delete(Address address);
        IResult Update(Address address);
        IDataResult<List<Address>> GetAll();
        IDataResult<Address> GetById(int ıd);

    }
}
