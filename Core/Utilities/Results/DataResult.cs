﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool success, T data) : base(success) { Data = data; }
        public DataResult(bool success, string message, T data) : base(success, message) { Data = data; }
        public T Data { get; }
    }
}
