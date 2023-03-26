using CatsTagram.Data.Models;
using CatsTagram.Features.Profiles.Models;
using CatsTagram.Infrastructure.Services;

namespace CatsTagram.Features.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel?> ByUser(string userId);
        Task<Result> Update(
            string userId,
            string? email,
            string userName,
            string? name,
            string? photoUrl,
            string? webSite,
            string? biography,
            Gender gender,
            bool isPrivate);
    }
}
