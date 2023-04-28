using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.CompanyDtos;
using Entity.DTOs.DepartmentDtos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {

        IDepartmentDal _departmentDal;
        ICompanyDal _companyDal;
        IBranchDal _branchDal;
        IMissionDal _missionDal;
        IEmployeeDal _employeeDal;

        public DepartmentManager(IDepartmentDal departmentDal, ICompanyDal companyDal, IBranchDal branchDal, IMissionDal missionDal, IEmployeeDal employeeDal)
        {
            _departmentDal = departmentDal;
            _companyDal = companyDal;
            _branchDal = branchDal;
            _missionDal = missionDal;
            _employeeDal = employeeDal;

        }
        public IResult Add(DepartmentAddRequestDto model)
        {



            var branch = _branchDal.Get(x => x.Id == model.BranchId);
            if (branch != null)
            {
                if (branch.IsDeleted == false)
                {
                    var department = new Department();
                    {

                        department.DepartmentName = model.DepartmentName;
                        department.BranchId = model.BranchId;



                    };
                    _departmentDal.Add(department);
                    return new SuccessResult(Messages.DepartmentAdded);
                }
            }

            return new ErrorResult(Messages.Not);


        }

        public IResult Delete(int id)
        {
            var department = _departmentDal.Get(x => x.Id == id);
            var mission = _missionDal.GetAll(x => x.DepartmentId == id);
            var epmloyee = _employeeDal.GetAll(x => x.Mission.DepartmentId == id);
            
            foreach (var m in mission)
            {
                foreach (var e in epmloyee)
                {
                    e.EndDate = DateTime.Now;
                    _employeeDal.Delete(e);
                }
               
                _missionDal.Delete(m);
            }
            _departmentDal.Delete(department);
            return new SuccessResult(Messages.DepartmentDeleted);
        }

        public IDataResult<List<DepartmentGetAllDto>> GetAll()
        {

            var department = _departmentDal.GetAllDepartmen();
            return new SuccessDataResult<List<DepartmentGetAllDto>>(department, Messages.DepartmentsListed);
            

        }

        public IDataResult<DepartmentGetByIdDto> GetById(int id)
        {
            var department = _departmentDal.GetByIdDepartmen(id);
            if (department !=null)           
            {
                return new SuccessDataResult<DepartmentGetByIdDto>(_departmentDal.GetByIdDepartmen(id));
            }
           return new ErrorDataResult<DepartmentGetByIdDto>(department,Messages.DepartmentNotExist);
        }

        public IResult Update(DepartmentUpdateRequestDto model)
        {
            var department = _departmentDal.Get(x=>x.Id==model.DepartmentId); 
            if (department != null)
            {
                department.DepartmentName= model.DepartmentName;
                _departmentDal.Update(department);
                return new SuccessResult(Messages.DepartmentUpdated);
            }
            return new ErrorResult(Messages.Not);
            
        }
    }
}
