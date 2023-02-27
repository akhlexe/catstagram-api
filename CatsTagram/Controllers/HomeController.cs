using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsTagram.Controllers
{
    public class HomeController : ApiContoller
    {
        [Authorize]
        public ActionResult Get()
        {
            return Ok("Works");
        }
    }
}