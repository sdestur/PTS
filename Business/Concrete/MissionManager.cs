using Business.Abstract;
using Business.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MissionManager : IMissionService
    {
        IMissionDal _missionDal;
        public MissionManager(IMissionDal missionDal)
        {
            _missionDal = missionDal;
        }
        public IResult Add(Mission mission)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Mission mission)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Mission>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Mission> GetById(int ıd)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
