﻿using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BaseEntity 
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
