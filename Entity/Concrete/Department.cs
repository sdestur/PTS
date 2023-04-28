using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public string DepartmentName { get; set; }
        [ForeignKey("BranchId")]
        public int? BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
