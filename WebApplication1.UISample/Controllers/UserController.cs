using Microsoft.AspNetCore.Mvc;
using RestSharp;
using WebApplication1.UISample.Models;

namespace WebApplication1.UISample.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        { 
            //api adresini tanımlayalım.
            RestClient client = new RestClient("http://localhost:5097");
            //endpointimizi yazalım.(swagger a bak. controller/action)
            RestRequest request = new RestRequest("/User/List", Method.Get);
            //get put hepsi var. Get<t> - generic hali- bana ne dönecek!!!
            var model = client.Get<ApiResponse<IEnumerable<UserQuery>>>(request);
            return View(model.data);
           
        }

    }
}
