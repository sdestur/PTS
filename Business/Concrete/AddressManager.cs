using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public IResult Add(Address address)
        {
            _addressDal.Add(address);
            return new SuccessResult(Messages.AddressAdded);
        }

        public IResult Delete(Address address)
        {
            throw new NotImplementedException();
            //var xx = address.IsDeleted==true;

        }

        public IDataResult<List<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Address> GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
