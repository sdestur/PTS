using Business.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMissionService
    {
        IResult Add(MissionAddRequestDtos model);
        IResult Delete(int id);
        IResult Update(MissionUpdateRequestDto model);
        IDataResult<List<MissionGetAllDto>> GetAll();
        IDataResult<MissionGetByIdDto> GetById(int ıd);
    }
}
