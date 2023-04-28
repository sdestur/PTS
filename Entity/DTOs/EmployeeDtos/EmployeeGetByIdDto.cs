using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.EmployeeDtos
{
    public class EmployeeGetByIdDto
    {
        public string CompanyName { get; set; }
        public string BranchName { get; set; }
        public string DepartmentName { get; set; }
        public string MissionName { get; set; }
        public string EmployeeName { get; set; }
    }
}
