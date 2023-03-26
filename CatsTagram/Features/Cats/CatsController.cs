using CatsTagram.Features.Cats.Models;
using CatsTagram.Infrastructure;
using CatsTagram.Infrastructure.Extensions;
using CatsTagram.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsTagram.Features.Cats
{
    [Authorize]
    public class CatsController : ApiContoller
    {
        private readonly ICatsService cats;
        private readonly ICurrentUserService currentUser;

        public CatsController(
            ICatsService cats,
            ICurrentUserService currentUser)
        {
            this.cats = cats;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<CatListingServiceModel>> Mine()
        {
            var userId = this.currentUser.GetId();

            return await this.cats.ByUserAsync(userId);
        }

        [HttpGet]
        [Route(WebConstants.Id)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
            => await cats.DetailsAsync(id);


        [HttpPost]
        public async Task<ActionResult> Create(CreateCatRequestModel model)
        {
            string userId = this.currentUser.GetId()
                ?? throw new UnauthorizedAccessException();

            int id = await cats.CreateAsync(
                model.ImageUrl,
                model.Description,
                userId);

            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.currentUser.GetId();

            bool updated = await this.cats.UpdateAsync(
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
            string? userId = this.currentUser.GetId();

            bool deleted = await this.cats.DeleteAsync(id, userId);

            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.Ok();
        }
    }
}
