using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfAddressDal : EfEntityRepositoryBase<Address, PersonelTakipSistemiContext>, IAddressDal
    {












        //private IUnitOfWork _unitOfWork;
        //public EfAddressDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
    }
}
