using Entity.Concrete;
using Entity.Enums;
using System;
using System.Collections.Generic;

namespace Entity.DTOs.EmployeeDtos
{
    public class EmployeeUpdateDto
    {
        public int EmployeeId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EducationTypeEnum EducationType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public int? MissionId { get; set; }
        public List<Address> Addresses { get; set; }

    }
}
