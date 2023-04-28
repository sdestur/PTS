using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.BranchDtos;
using Entity.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, PersonelTakipSistemiContext>, IEmployeeDal
    {

        public List<EmployeeGetAllDto> GetAllEmploye()
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = context.Employees.Select(x => new EmployeeGetAllDto
                {
                    CompanyName = x.Mission.Department.Branch.Company.CompanyName,
                    BranchName = x.Mission.Department.Branch.BranchName,
                    DepartmentName = x.Mission.Department.DepartmentName,
                    MissionName = x.Mission.MissionName,
                    EmployeeName = x.FirstName + " " + x.LastName,
                }); ;
                return query.ToList();
            }

        }

        public EmployeeGetByIdDto GetById(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext()) 
            {
                
                    var query = from employee in context.Employees
                                where employee.Id == id 
                                select new EmployeeGetByIdDto
                                {
                                    CompanyName = employee.Mission.Department.Branch.Company.CompanyName,
                                    BranchName = employee.Mission.Department.Branch.BranchName,
                                    DepartmentName = employee.Mission.Department.DepartmentName,
                                    MissionName= employee.Mission.MissionName,
                                    EmployeeName = employee.FirstName + " " + employee.LastName,
                                };
                    return query.FirstOrDefault();


                
            }

        }

        public EmployeeUpdateDto EmployeeUpdate(int id)
        {
            using (PersonelTakipSistemiContext context = new PersonelTakipSistemiContext())
            {
                var query = (from personnel in context.Employees
                             let address = (from address in context.Addresses
                                            where address.EmployeeId == id
                                            select new Address
                                            {
                                                Id = address.Id,
                                                AddressDescription = address.AddressDescription,
                                            }).ToList()

                             where personnel.Id == id
                             select new EmployeeUpdateDto
                             {
                                 EmployeeId = personnel.Id,
                                 Addresses = address,
                                 FirstName = personnel.FirstName,
                                 LastName = personnel.LastName,
                             }).FirstOrDefault();

                return query;
            }

            //private IUnitOfWork _unitOfWork;
            //public EfEmployeeDal(IUnitOfWork unitOfWork) : base(unitOfWork)
            //{
            //    _unitOfWork = unitOfWork;
            //}

        }
    }

}