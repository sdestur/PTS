using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.AddressDtos;
using Entity.DTOs.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, PersonelTakipSistemiContext>, IAddressDal
    {




        public AddressGetByIdDto GetByIdAddress(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from address in context.Addresses
                            where address.Id == id 
                            select new AddressGetByIdDto
                            {
                               AddressDescription=address.AddressDescription
                            };
                return query.FirstOrDefault();


            }
        }







        //private IUnitOfWork _unitOfWork;
        //public EfAddressDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

    }
}
