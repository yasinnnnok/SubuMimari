namespace SUBU.Models;

public class DataResult<T> : Result, IDataResult<T>
{
	public DataResult(bool success, T data) : base(success)
	{
		Data = data;
	}

	public DataResult(bool success, string message, T data) : base(success, message)
	{
		Success = success;
		Message = message;
		Data = data;
	}
	
	public DataResult(string message) : base(default, message)
	{
		Message = message;
	}

	public DataResult(bool success, string message) : base(success, message)
	{
		Success = success;
		Message = message;
	}

	public T Data { get; set; }
}
