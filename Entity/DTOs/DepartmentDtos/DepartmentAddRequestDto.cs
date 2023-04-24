using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.DepartmentDtos
{
    public class DepartmentAddRequestDto
    {
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string DepartmentName { get; set; }
    }
}
