using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.UISample.Core.Result.Abstract
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; set; }
    }
}
