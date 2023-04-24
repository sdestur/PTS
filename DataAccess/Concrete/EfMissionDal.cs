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
    public class EfMissionDal : EfEntityRepositoryBase<Mission, PersonelTakipSistemiContext>, IMissionDal
    {















        //private IUnitOfWork _unitOfWork;
        //public EfMissionDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
    }
}
