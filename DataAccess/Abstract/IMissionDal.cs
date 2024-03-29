﻿using Entity.Concrete;
using Entity.DTOs.DepartmentDtos;
using Entity.DTOs.MissionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMissionDal : IEntityRepository<Mission>
    {
        List<MissionGetAllDto> GetAllMission();
        MissionGetByIdDto GetByIdMission(int id);
    }
}
