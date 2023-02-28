using CatsTagram.Data;
using CatsTagram.Data.Models;
using CatsTagram.Infrastructure;
using CatsTagram.Models.Cats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatsTagram.Controllers
{
    public class CatsController : ApiContoller
    {
        private readonly CatstagramDbContext data;

        public CatsController(CatstagramDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            string userId = this.User.GetId()
                ?? throw new UnauthorizedAccessException();

            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId,
            };

            this.data.Add(cat);
            await this.data.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}
