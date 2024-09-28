using HeroesAPI.Collections;
using MongoDB.Driver;

namespace HeroesAPI.Repositories;

public class HeroisRepository : IHeroisRepository
{
    private readonly IMongoCollection<Herois> _collection;
    public HeroisRepository(IMongoDatabase mongoDatabase)
    {
        _collection = mongoDatabase.GetCollection<Herois>("herois");
    }

    public async Task CreateAsync(Herois herois) =>
        await _collection.InsertOneAsync(herois);
    
    public async Task DeleteAsync(string id) =>
        await _collection.DeleteOneAsync(h => h.Id == id);

    public async Task<List<Herois>> GetAllAsync() =>
        await _collection.Find(h => true).ToListAsync();

    public async Task<Herois> GetByIdAsync(string id) =>
        await _collection.Find(h => h.Id == id).FirstOrDefaultAsync();

    public async Task UpdateAsync(Herois herois) =>
        await _collection.ReplaceOneAsync(h => h.Id == herois.Id, herois);
}
