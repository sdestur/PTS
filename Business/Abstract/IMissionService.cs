using Business.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMissionService
    {
        IResult Add(Mission mission);
        IResult Delete(Mission mission);
        IResult Update(Mission mission);
        IDataResult<List<Mission>> GetAll();
        IDataResult<Mission> GetById(int ıd);
    }
}
