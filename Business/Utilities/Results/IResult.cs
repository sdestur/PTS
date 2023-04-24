﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; } //sadece get. yani sadece okunabilir.  
        string Message { get; }
    }
}
