﻿namespace SUBU.Models;

public class SuccessDataResult<T> : DataResult<T>
{

    public SuccessDataResult(T data) : base(true, data)
    {
    }

    public SuccessDataResult(T data, string message) : base(true, message, data)
    {
    }

    public SuccessDataResult(string message) : base(true, message, default)
    {
    }
}
