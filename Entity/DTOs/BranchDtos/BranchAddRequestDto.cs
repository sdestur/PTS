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
        
        public int CompanyId { get; set; }
        public string BranchName { get; set; }

    }
}
