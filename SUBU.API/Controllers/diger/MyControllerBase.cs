using Microsoft.AspNetCore.Mvc;
using SUBU.Models;
using SUBU.Models.diger;

namespace SUBU.API.Controllers.diger
{
  
    //dataResult yapısının 
    public class MyControllerBase : ControllerBase
    {
       
        //data ve mesaj alır
        [NonAction]
        public IActionResult Success<T>(T data, params string[] messages)
        {
            var response = new ResponseResult<T>();
            response.Success = true;
            response.Messages.AddRange(messages);
            response.Data = data;

            return Ok(response);
        }


        //sadece Mesaj alan
        [NonAction]
        public IActionResult Success(params string[] messages)
        {
            var response = new ResponseResult<object>();
            response.Success = true;
            response.Messages.AddRange(messages);
            response.Data = null;

            return Ok(response);
        }

        //Error-BadRequstte kullanabiliriz.
        [NonAction]
        public IActionResult Error(params string[] messages)
        {
            var response = new ResponseResult<object>();
            response.Success = false;
            response.Messages.AddRange(messages);
            response.Data = null;

            return BadRequest(response);
        }

        [NonAction]
        public IActionResult NotFound(params string[] messages)
        {
            var response = new ResponseResult<object>();
            response.Success = false;
            response.Messages.AddRange(messages);
            response.Data = null;

            return NotFound(response);
        }
    }
}
