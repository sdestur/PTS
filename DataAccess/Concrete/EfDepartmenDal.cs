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
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, PersonelTakipSistemiContext>, IDepartmentDal
    {











        //private IUnitOfWork _unitOfWork;
        //public EfDepartmenDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
    }
}
