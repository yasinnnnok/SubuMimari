namespace SUBU.Models;

public class ErrorDataResult<T> : DataResult<T>
{
	public ErrorDataResult(T data) : base(false, data)
	{
	}
	public ErrorDataResult(T data, string message) : base(false, message, data)
	{
	}
	public ErrorDataResult(string message) : base(false, message, default)
	{
	}

}
