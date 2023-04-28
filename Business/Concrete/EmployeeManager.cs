using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.UnitOfWorkDesign;
using Entity.Concrete;
using Entity.DTOs.EmployeeDtos;
using Entity.DTOs.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
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
        ICompanyDal _companyDal;

        public EmployeeManager(IEmployeeDal employeeDal, IAddressDal addressDal, IDepartmentDal departmentDal, IMissionDal missionDal, IBranchDal branchDal, ICompanyDal companyDal)
        {
            _employeeDal = employeeDal;
            _addressDal = addressDal;
            _departmentDal = departmentDal;
            _missionDal = missionDal;
            _branchDal = branchDal;
            _companyDal = companyDal;
        }
        public IResult Add(EmployeeAddRequestDto model)
        {
            var mission = _missionDal.Get(x => x.Id == model.MissionId);

            {
                if (mission != null)
                {
                    if (mission.IsDeleted == false)
                    {
                        var employee = new Employee();
                        {
                            employee.IdentityNumber = model.IdentityNumber;
                            employee.FirstName = model.FirstName;
                            employee.LastName = model.LastName;
                            employee.EducationType = model.EducationType;
                            employee.DateOfBirth = model.DateOfBirth;
                            employee.ContactNumber = model.ContactNumber;
                            employee.IsActive = true;

                            employee.MissionId = model.MissionId;


                        };
                        _employeeDal.Add(employee);
                        var address = new Address
                        {
                            AddressDescription = model.AddressDescription,
                            EmployeeId = employee.Id
                        };

                        _addressDal.Add(address);

                        return new SuccessResult(Messages.EmployeeAdded);
                    }
                }
            }
            return new ErrorResult(Messages.Not);
        }

        public IResult Delete(int id)
        {
            var address = _addressDal.GetAll(x=>x.EmployeeId == id);
            var employee = _employeeDal.Get(x => x.Id == id);
            foreach (var a in address)
            {
                _addressDal.Delete(a);
            }
            employee.EndDate= DateTime.Now;
            _employeeDal.Delete(employee);
            return new SuccessResult(Messages.EmployeeDeleted);
        }

        public IDataResult<List<EmployeeGetAllDto>> GetAll()
        {
            return new SuccessDataResult<List<EmployeeGetAllDto>>(_employeeDal.GetAllEmploye());

        }

        public IDataResult<EmployeeGetByIdDto> GetById(int id)
        {
            var employee = _employeeDal.GetById(id);
            if (employee != null)
            {
                return new SuccessDataResult<EmployeeGetByIdDto>(_employeeDal.GetById(id));
            }

            return new ErrorDataResult<EmployeeGetByIdDto>(employee, Messages.Not);
        }

        public IResult Update(EmployeeRequestDto model)
        {
            var employee = _employeeDal.Get(x => x.Id == model.EmployeeId);
            var employeeInfo = _employeeDal.EmployeeUpdate(model.EmployeeId);

            if (employee != null)
            {
                employeeInfo.IdentityNumber = model.IdentityNumber == null ? employee.IdentityNumber : model.IdentityNumber;
                employeeInfo.FirstName = model.FirstName == null ? employee.FirstName : model.FirstName;
                employeeInfo.LastName = model.LastName == null ? employee.LastName : model.LastName;
                employeeInfo.EducationType =model.EducationType == null ? employee.EducationType : model.EducationType;
                employeeInfo.DateOfBirth=model.DateOfBirth == null ? employee.DateOfBirth : model.DateOfBirth;
                employeeInfo.ContactNumber=model.ContactNumber == null ? employee.ContactNumber : model.ContactNumber;
                employeeInfo.MissionId=model.MissionId == null ? employee.MissionId : model.MissionId;

                employee.IdentityNumber = employeeInfo.IdentityNumber;
                employee.FirstName = employeeInfo.FirstName;
                employee.LastName = employeeInfo.LastName;
                employee.MissionId = (int)employeeInfo.MissionId;
                employee.EducationType = employeeInfo.EducationType;
                employee.DateOfBirth=employeeInfo.DateOfBirth;
                employee.ContactNumber = employeeInfo.ContactNumber;
                
                

                var address = _addressDal.Get(x => x.EmployeeId == model.EmployeeId && x.Id == model.AddressId);
                if (address != null)
                {
                    address.AddressDescription = model.AddressDescription;
                    address.EmployeeId = employeeInfo.EmployeeId;
                    _addressDal.Update(address);
                }


                _employeeDal.Update(employee);
                return new SuccessResult("Güncellendi");
            }
            return new ErrorResult("Kullanıcı bulunamadı");


        }

        

    }



}
