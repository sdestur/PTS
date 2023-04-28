using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.AddressDtos
{
    public class AddressUpdateRequestDto
    {
        public int AddressId { get; set; }
        public string AddressDescription { get; set; }
    }
}
