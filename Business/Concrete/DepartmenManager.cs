using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs.DepartmentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        //interfacesi düzelt
        IDepartmentDal _departmentDal;
        
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
           
        }
        public IResult Add(DepartmentAddRequestDto model)
        {
            var departmen = new Department
            {
                DepartmentName = model.DepartmentName,
                Branches=new HashSet<Branch> (){ new() { Id= model.BranchId , CompanyId =model.CompanyId} }
            };
            _departmentDal.Add(departmen);
            
            return new SuccessResult(Messages.DepartmentAdded);
        }

        public IResult Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Department>> GetAll()
        {
            throw new NotImplementedException();

        }

        public IDataResult<Department> GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
