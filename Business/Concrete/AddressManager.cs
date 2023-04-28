using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs.AddressDtos;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        IAddressDal _addressDal;
        IEmployeeDal _employeeDal;
        public AddressManager(IAddressDal addressDal, IEmployeeDal employeeDal)
        {
            _addressDal = addressDal;
            _employeeDal = employeeDal;
        }
        public IResult Add(AddressAddRequestDto model)
        {
            var employee = _employeeDal.Get(x => x.Id == model.EmployeeId);
            if (employee != null)
            {
                var address = new Address();
               address.EmployeeId = model.EmployeeId;
                address.AddressDescription = model.AddressDescription;
                _addressDal.Add(address);
                return new SuccessResult(Messages.BranchAdded);
            }
            return new ErrorResult(Messages.Not);
        }

        public IResult Delete(int id)
        {
            var address = _addressDal.Get(x => x.Id == id);

           
            _addressDal.Delete(address);
            return new SuccessResult(Messages.MissionDeleted);

        }

        public IDataResult<List<Address>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<AddressGetByIdDto> GetById(int id)
        {
            var address = _addressDal.GetByIdAddress(id);
            if (address != null)
            {
                return new SuccessDataResult<AddressGetByIdDto>(address, Messages.BranchListed);
            }
            return new ErrorDataResult<AddressGetByIdDto>(Messages.BranchNotExist);
        }

        public IResult Update(AddressUpdateRequestDto model)
        {
            var address = _addressDal.Get(a => a.Id == model.AddressId);
            if (address != null)
            {
               address.AddressDescription = model.AddressDescription;
                _addressDal.Update(address);
                return new SuccessResult(Messages.BranchUpdated);
            }
            return new ErrorResult(Messages.Not);
        }
    }
}
