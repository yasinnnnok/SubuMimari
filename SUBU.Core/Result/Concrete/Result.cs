﻿using SUBU.Core.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Core.Result.Concrete
{
    public class Result : IResult
    {
        public Result(bool success)
        {
            Success = success;
            
        }
        public Result(bool success, string message):this(success) 
        {            
            Message = message;
        }

        public bool Success { get; set; }

        public string Message { get; set; }
    }
}
