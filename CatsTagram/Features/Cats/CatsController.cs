using CatsTagram.Features.Cats.Models;
using CatsTagram.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsTagram.Features.Cats
{
    [Authorize]
    public class CatsController : ApiContoller
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this.User.GetId();

            return await this.catsService.ByUser(userId);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
            => await catsService.Details(id);


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

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.GetId();

            bool updated = await this.catsService.Update(
                model.Id,
                model.Description,
                userId);

            if (!updated)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}
