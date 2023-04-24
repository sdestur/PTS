using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Department : BaseEntity, IEntity
    {
        public Department()
        {
            Branches = new HashSet<Branch>();
        }

        public string DepartmentName { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual ICollection<Employee> Employees {get; set; }
    }
}
