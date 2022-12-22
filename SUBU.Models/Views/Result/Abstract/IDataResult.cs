namespace SUBU.Models;

public interface IDataResult<T>:IResult
{
    T Data { get; set; }
}
