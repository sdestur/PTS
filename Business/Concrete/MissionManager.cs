using Business.Abstract;
using Business.Constans;
using Business.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs.DepartmentDtos;
using Entity.DTOs.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MissionManager : IMissionService
    {
        IDepartmentDal _departmentDal;
        IMissionDal _missionDal;
        IBranchDal _branchDal;
        ICompanyDal _companyDal;
        IEmployeeDal _employeeDal;

        public MissionManager(IDepartmentDal departmentDal, IMissionDal missionDal, IBranchDal branchDal, ICompanyDal companyDal, IEmployeeDal employeeDal)
        {
            _departmentDal = departmentDal;
            _missionDal = missionDal;
            _branchDal = branchDal;
            _companyDal = companyDal;
            _employeeDal = employeeDal;
        }
        public IResult Add(MissionAddRequestDtos model)
        {

            var department = _departmentDal.Get(x => x.Id == model.DepartmentId);
            if (department != null)
            {
                
                    var mission = new Mission();
                    {
                        mission.DepartmentId = department.Id;
                        mission.MissionName = model.MissionName;

                    }
                    _missionDal.Add(mission);
                    return new SuccessResult(Messages.MissionAdded);
                

            }
            return new ErrorResult(Messages.Not);
        }

        public IResult Delete(int id)
        {
            var mission = _missionDal.Get(x => x.Id == id);
            var employee = _employeeDal.GetAll(x => x.MissionId == id);
           
            foreach (var e in employee)
            {
                e.EndDate = DateTime.Now;
                _employeeDal.Delete(e);
            }
            _missionDal.Delete(mission);
            return new SuccessResult(Messages.MissionDeleted);
        }


        public IDataResult<List<MissionGetAllDto>> GetAll()
        {
            var result = _missionDal.GetAllMission();
            return new SuccessDataResult<List<MissionGetAllDto>>(result, Messages.MissionsListed);
        }

        public IDataResult<MissionGetByIdDto> GetById(int id)
        {
            var mission = _missionDal.GetByIdMission(id);
            if (mission !=null)
            {
                return new SuccessDataResult<MissionGetByIdDto>(_missionDal.GetByIdMission(id));
            }

            return new ErrorDataResult<MissionGetByIdDto>(mission,Messages.Not);
        }

        public IResult Update(MissionUpdateRequestDto model)
        {
            var mission = _missionDal.Get(x=>x.Id==model.MissionId);
            if (mission !=null)
            {
                mission.MissionName = model.MissionName;
                _missionDal.Update(mission);
                return new SuccessResult(Messages.MissionUpdated);
            }
            return new ErrorResult(Messages.Not);
        }
    }
}
