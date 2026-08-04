using Backend.DTOs;

namespace Backend.Services
{
    public interface IBeerService
    {
        Task<IEnumerable<BeerDto>> GetBeer();
        Task<BeerDto> GetBeerById(int id);
        Task<BeerDto> AddBeer(BeerInsertDto beerInsertDto);
        Task<BeerDto> UpdateBeer(int id, BeerUpdateDto beerUpdateDto);
        Task<BeerDto> DeleteBeer(int id);
    }
}
