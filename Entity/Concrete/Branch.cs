using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Branch : BaseEntity, IEntity
    {
       
        public string BranchName { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
        
       


    }
}
