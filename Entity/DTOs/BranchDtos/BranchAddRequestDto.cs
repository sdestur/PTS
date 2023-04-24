using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.BranchDtos
{
    public class BranchAddRequestDto
    {
        public string BranchName { get; set; }
        public int CompanyId { get; set; }
        
    }
}
