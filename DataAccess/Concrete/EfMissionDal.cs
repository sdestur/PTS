using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.DepartmentDtos;
using Entity.DTOs.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfMissionDal : EfEntityRepositoryBase<Mission, PersonelTakipSistemiContext>, IMissionDal
    {


       

        public List<MissionGetAllDto> GetAllMission()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = context.Missions.Select(x => new MissionGetAllDto
                {
                    CompanyName = x.Department.Branch.Company.CompanyName,
                    BranchName = x.Department.Branch.BranchName,
                    DepartmentName = x.Department.DepartmentName,
                    MissionName = x.MissionName,

                });
                return query.ToList();
            }
        }

        public MissionGetByIdDto GetByIdMission(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = from m in context.Missions
                            where m.Id == id 
                            select new MissionGetByIdDto
                            {
                                CompanyName = m.Department.Branch.Company.CompanyName,
                                BranchName = m.Department.Branch.BranchName,
                                DepartmentName = m.Department.DepartmentName,
                                MissionName = m.MissionName,
                            };

                return query.FirstOrDefault();
            }
        }













        //private IUnitOfWork _unitOfWork;
        //public EfMissionDal(IUnitOfWork unitOfWork) : base(unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}
    }
}
