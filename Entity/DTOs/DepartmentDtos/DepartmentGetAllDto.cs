using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.DepartmentDtos
{
    public class DepartmentGetAllDto
    {
        public string  CompanyName { get; set; }
        public string  BranchName { get; set; }
        public string DepartmentName { get; set; }
    }
}
