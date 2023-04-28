using Entity.Abstract;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Employee : BaseEntity, IEntity
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EducationTypeEnum EducationType { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ContactNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        [ForeignKey("MissionId")]
        public int MissionId { get; set; }
        public Mission Mission { get; set; }




    }

    
}
