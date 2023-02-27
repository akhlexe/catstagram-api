using CatsTagram.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsTagram.Controllers
{
    public class CatsController : ApiContoller
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {

        }
    }
}
