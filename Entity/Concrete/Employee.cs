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
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        [ForeignKey("BranchId")]
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [ForeignKey("MissionId")]
        public int MissionId { get; set; }
        public virtual Mission Mission { get; set; }
        [ForeignKey("DepartmanId")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

    }
}
