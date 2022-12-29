﻿namespace SUBU.Models;

public class ApiResponse<T>
{
	public bool Success { get; set; }
	public string Message { get; set; }
	public T Data { get; set; }
}


public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
}