using Entity.Enums;
using System;

namespace Entity.DTOs.EmployeeDtos
{
    public class EmployeeRequestDto
    {
        public int EmployeeId { get; set; }
        public int AddressId { get; set; }
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EducationTypeEnum EducationType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public int? MissionId { get; set; }
        public string AddressDescription { get; set; }

    }
}
