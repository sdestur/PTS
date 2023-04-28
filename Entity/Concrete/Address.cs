using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Address : BaseEntity , IEntity
    {
        public string AddressDescription { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }


    }
}
