using CatsTagram.Features.Cats.Models;
using CatsTagram.Infrastructure;
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

            return await this.catsService.ByUserAsync(userId);
        }

        [HttpGet]
        [Route(WebConstants.Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
            => await catsService.DetailsAsync(id);


        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            string userId = User.GetId()
                ?? throw new UnauthorizedAccessException();

            int id = await catsService.CreateAsync(
                model.ImageUrl,
                model.Description,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.User.GetId();

            bool updated = await this.catsService.UpdateAsync(
                model.Id,
                model.Description,
                userId);

            if (!updated)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [HttpDelete]
        [Route(WebConstants.Id)]
        public async Task<ActionResult> Delete(int id)
        {
            string? userId = this.User.GetId();

            bool deleted = await this.catsService.DeleteAsync(id, userId);

            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}
