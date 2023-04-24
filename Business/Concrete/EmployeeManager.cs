using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        IEmployeeDal _employeeDal;
        IAddressDal _addressDal;
        IDepartmentDal _departmentDal;
        IMissionDal _missionDal;
        IBranchDal _branchDal;

        public EmployeeManager(IEmployeeDal employeeDal, IAddressDal addressDal, IDepartmentDal departmentDal, IMissionDal missionDal, IBranchDal branchDal)
        {
            _employeeDal = employeeDal;
            _addressDal = addressDal;
            _departmentDal = departmentDal;
            _missionDal = missionDal;
            _branchDal = branchDal;
        }
        public IResult Add(EmployeeAddRequestDto model)
        {

            var employee = new Employee
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                IdentityNumber = model.IdentityNumber,
                DateOfBirth = model.DateOfBirth,
                EducationType = model.EducationType,
                IsActive = true,
                PhoneNumber1 = model.PhoneNumber1,
                PhoneNumber2 = model.PhoneNumber2,
                StartingDate = DateTime.Now,
                MissionId = model.MissionId,
                DepartmentId = model.DepartmentId,
                BranchId = model.BranchId,


            };
            _employeeDal.Add(employee);

            //var mission = new Mission
            //{
            //    //MissionName= model.MissionName,
            //    Employees = new HashSet<Employee> { new() { MissionId = model.MissionId } }
            //};
            //_missionDal.Add(mission);

            //var department = new Department
            //{
            //    //Burayı kontrol et
            //    //DepartmentName = model.DepartmentName,
            //    Employees = new HashSet<Employee> { new() { DepartmentId = model.DepartmentId } }

            //};
            //_departmentDal.Add(department);


            //var branch = new Branch
            //{
            //    //BranchName = model.BranchName,
            //    Employees = new HashSet<Employee> { new() { BranchId = model.BranchId } }
            //};
            //_branchDal.Add(branch);

            var address = new Address
            {
                AddressDescription = model.AddressDescription,
                EmployeeId = employee.Id
            };

            _addressDal.Add(address);

          

            return new SuccessResult(Messages.EmployeeAdded);


        }

        public IResult Delete(Employee employee)
        {
            //employee.IsDeleted = true;
            throw new NotImplementedException();
        }

        public IDataResult<List<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Employee> GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
