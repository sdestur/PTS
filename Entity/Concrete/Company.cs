using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Company : BaseEntity, IEntity
    {
        
        public string CompanyName { get; set; }
 
        public virtual ICollection<Branch> Branchs { get; set; }
    }
}
