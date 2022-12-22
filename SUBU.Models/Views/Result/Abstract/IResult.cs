namespace SUBU.Models;

public  interface IResult
{
    public bool Success { get; }
    public string Message { get; }
}
