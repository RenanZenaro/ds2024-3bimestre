using HeroesAPI.Collections;

namespace HeroesAPI.Repositories;

public interface IHeroisRepository
{
    Task<List<Herois>> GetAllAsync();
    Task<Herois> GetByIdAsync(string id);
    Task CreateAsync(Herois herois);
    Task UpdateAsync(Herois herois);
    Task DeleteAsync(string id);
}
