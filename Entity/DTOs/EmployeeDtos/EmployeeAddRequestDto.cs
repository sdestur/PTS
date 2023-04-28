using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.EmployeeDtos
{
    public class EmployeeAddRequestDto
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EducationTypeEnum EducationType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public int MissionId { get; set; }  
        public string AddressDescription { get; set; }
        
    }
}
