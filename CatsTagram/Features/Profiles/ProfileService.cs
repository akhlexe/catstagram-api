using CatsTagram.Data;
using CatsTagram.Data.Models;
using CatsTagram.Features.Profiles.Models;
using CatsTagram.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace CatsTagram.Features.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext data;

        public ProfileService(CatstagramDbContext data) => this.data = data;

        public Task<ProfileServiceModel?> ByUser(string userId)
            => this.data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileServiceModel
                {
                    Name = u.Profile.Name,
                    Biography = u.Profile.Biography,
                    Gender = u.Profile.Gender.ToString(),
                    PhotoUrl = u.Profile.PhotoUrl,
                    IsPrivate = u.Profile.IsPrivate,
                    WebSite = u.Profile.WebSite
                })
                .FirstOrDefaultAsync();

        public async Task<Result> Update(
            string userId,
            string? email,
            string? userName,
            string? name,
            string? photoUrl,
            string? webSite,
            string? biography,
            Gender gender,
            bool isPrivate)
        {
            User? user = await this.data.Users.FindAsync(userId);

            if (user == null)
            {
                return "User does not exist";
            }

            Result result = await this.ChangeProfileEmailAsync(user, userId, email);
            if (result.Failed)
            {
                return result;
            }

            result = await this.ChangeProfileUserNameAsync(user, userId, userName);
            if (result.Failed)
            {
                return result;
            }

            this.ChangeProfile(user, name, photoUrl, webSite, biography, gender, isPrivate);

            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeProfileEmailAsync(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                bool emailExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (emailExists)
                {
                    return "The provided email is already taken.";
                }

                user.Email = email;
            }

            return true;
        }

        private async Task<Result> ChangeProfileUserNameAsync(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                bool userNameExists = await this.data
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == userName);

                if (userNameExists)
                {
                    return "The provided username is already taken.";
                }

                user.UserName = userName;
            }

            return true;
        }

        private void ChangeProfile(
            User user,
            string? name,
            string? photoUrl,
            string? webSite,
            string? biography,
            Gender gender,
            bool isPrivate)
        {
            if (user.Profile.Name != name)
            {
                user.Profile.Name = name;
            }

            if (user.Profile.PhotoUrl != photoUrl)
            {
                user.Profile.PhotoUrl = photoUrl;
            }

            if (user.Profile.WebSite != webSite)
            {
                user.Profile.WebSite = webSite;
            }

            if (user.Profile.Biography != biography)
            {
                user.Profile.Biography = biography;
            }

            if (user.Profile.Gender != gender)
            {
                user.Profile.Gender = gender;
            }

            if (user.Profile.IsPrivate != isPrivate)
            {
                user.Profile.IsPrivate = isPrivate;
            }
        }
    }
}
