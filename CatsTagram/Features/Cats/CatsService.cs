using CatsTagram.Data;
using CatsTagram.Data.Models;
using CatsTagram.Features.Cats.Models;
using Microsoft.EntityFrameworkCore;

namespace CatsTagram.Features.Cats
{
    public class CatsService : ICatsService
    {
        private readonly CatstagramDbContext data;

        public CatsService(CatstagramDbContext data) => this.data = data;

        public async Task<int> CreateAsync(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                UserId = userId,
                ImageUrl = imageUrl,
            };

            data.Add(cat);
            await data.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<IEnumerable<CatListingServiceModel>> ByUserAsync(string userId)
            => await this.data
                .Cats
                .Where(c => c.UserId == userId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CatListingServiceModel
                {
                    Id = c.Id,
                    ImageUrl = c.ImageUrl
                })
                .ToListAsync();

        public async Task<CatDetailsServiceModel> DetailsAsync(int id)
            => await this.data
                .Cats
                .Where(c => c.Id == id)
                .Select(c => new CatDetailsServiceModel
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description,
                    UserName = c.User.UserName
                })
                .FirstOrDefaultAsync();

        public async Task<bool> UpdateAsync(int id, string description, string userId)
        {
            var cat = await this.GetByIdAndUserId(id, userId);

            if (cat == null)
            {
                return false;
            }

            cat.Description = description;
            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id, string userId)
        {
            var cat = await this.GetByIdAndUserId(id, userId);

            if (cat == null)
            {
                return false;
            }

            this.data.Cats.Remove(cat);
            await this.data.SaveChangesAsync();

            return true;
        }

        private async Task<Cat> GetByIdAndUserId(int id, string userId)
            => await this.data
                .Cats
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
