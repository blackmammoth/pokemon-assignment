using P.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace P.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IMongoCollection<Pokemon> _pokemonCollection;

        public PokemonService(IMongoClient mongoClient, IOptions<MongoDBSettings> settings)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _pokemonCollection = database.GetCollection<Pokemon>("Poke");
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _pokemonCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _pokemonCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _pokemonCollection.InsertOneAsync(pokemon);
        }

        public async Task UpdateAsync(int id, Pokemon updatedPokemon)
        {
            await _pokemonCollection.ReplaceOneAsync(p => p.Id == id, updatedPokemon);
        }

        public async Task DeleteAsync(int id)
        {
            await _pokemonCollection.DeleteOneAsync(p => p.Id == id);
        }
    }
}