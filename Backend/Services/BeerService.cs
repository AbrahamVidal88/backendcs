using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class BeerService : IBeerService
    {
        private StoreContext _context;

        public BeerService(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BeerDto>> GetBeer() =>
            await _context.Beers.Select(b => new BeerDto
            {
                Id = b.BeerId,
                Name = b.Name,
                BrandId = b.BrandId,
                Alcohol = b.Alcohol
            }).ToListAsync();
        public async Task<BeerDto> GetBeerById(int id)
        {
            var beer = await _context.Beers.FindAsync(id);

            if (beer != null)
            {
                var beerDto = new BeerDto
                {
                    Id = beer.BeerId,
                    Name = beer.Name,
                    Alcohol = beer.Alcohol,
                    BrandId = beer.BrandId
                };

                return beerDto;
             }
            return null;
        }
        public async Task<BeerDto> AddBeer(BeerInsertDto beerInsertDto)
        {
            var beer = new Beer
            {
                Name = beerInsertDto.Name,
                BrandId = beerInsertDto.BrandId,
                Alcohol = beerInsertDto.Alcohol
            };

            await _context.AddAsync(beer);
            await _context.SaveChangesAsync();

            var beerDto = new BeerDto
            {
                Id = beer.BeerId,
                Name = beer.Name,
                Alcohol = beer.Alcohol,
                BrandId = beer.BrandId
            };

            return beerDto;
        }
        public async Task<BeerDto> UpdateBeer(int id, BeerUpdateDto beerUpdateDto)
        {
            throw new NotImplementedException();
        }
        public async Task<BeerDto> DeleteBeer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
