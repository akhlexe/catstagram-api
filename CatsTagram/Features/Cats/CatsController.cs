using CatsTagram.Data;
using CatsTagram.Data.Models;
using CatsTagram.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CatsTagram.Features.Cats
{
    public class CatsController : ApiContoller
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            string userId = User.GetId()
                ?? throw new UnauthorizedAccessException();

            int id = await catsService.Create(
                model.ImageUrl,
                model.Description,
                userId);

            return Created(nameof(this.Create), id);
        }
    }
}
