using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.CompanyDtos;
using Entity.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, PersonelTakipSistemiContext>, IDepartmentDal
    {
        //public void Add(DepartmentAddRequestDto model)
        //{
        //    using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
        //    {
        //        var query = from d in context.Departments
        //                    join c in context.Companys
        //                    on d.Branch.CompanyId equals c.Id
        //                    where c.IsDeleted == false
        //                     new DepartmentAddRequestDto
        //                    {
        //                        CompanyId = model.CompanyId,
        //                        BranchId = model.BranchId,
        //                        DepartmentName = model.DepartmentName,

        //                    };
                

        //    }
        //}

        public List<DepartmentGetAllDto> GetAllDepartmen()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = context.Departments.Select(x => new DepartmentGetAllDto
                {
                    CompanyName = x.Branch.Company.CompanyName,
                    BranchName = x.Branch.BranchName,
                    DepartmentName = x.DepartmentName
                });
                return query.ToList();
            }
        }

        public DepartmentGetByIdDto GetByIdDepartmen(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from d in context.Departments
                            where d.Id == id 
                            select new DepartmentGetByIdDto
                            {
                                CompanyName =d.Branch.Company.CompanyName,
                                BranchName = d.Branch.BranchName,
                                DepartmentName = d.DepartmentName
                            };
                
                return query.FirstOrDefault();
            }
        }





        //private IUnitOfWork _unitOfWork;
        //public EfDepartmenDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;

    }
}
