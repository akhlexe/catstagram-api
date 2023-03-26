using CatsTagram.Features.Profiles.Models;
using CatsTagram.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatsTagram.Features.Profiles
{
    public class ProfilesController : ApiContoller
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(
            IProfileService profiles,
            ICurrentUserService currentUser)
        {
            this.currentUser = currentUser;
            this.profiles = profiles;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel?>> Mine()
            => await this.profiles
            .ByUser(this.currentUser.GetId());

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            string userId = this.currentUser.GetId();

            var result = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.PhotoUrl,
                model.WebSite,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (result.Failed)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
