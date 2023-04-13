using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using DB = PokemonApp.Models.DBModels;
using Req = PokemonApp.Models.Request;
using Res = PokemonApp.Models.Response;
using PokemonApp.Repository.Interface;
using static PokemonApp.Helper.Helper;

namespace PokemonApp.Repository.Service
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly ApplicationdbContext _dbContext;

        public PokemonRepository(ApplicationdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Logic Implementation for Add(Name,ImageURL) in database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> Add(Req.Pokemon model)
        {
            try
            {
                DB.Pokemon pokemon = new()
                {
                    Name = model.Name,
                    ImageUrl = model.ImageUrl,
                    
                };
                 
                await _dbContext.Pokemons.AddAsync(pokemon);
                return await _dbContext.SaveChangesAsync()>0;

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        ///  Performing Deleting  Operation in Pokemon Using Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<bool> Delete(int id)
        {
            try
            {
                var pokemon = _dbContext.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
                if (pokemon != null)
                {

                    _dbContext.Remove(pokemon);
                    return await _dbContext.SaveChangesAsync()>0;
                }
                return false; 
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Getting all the  pokemons details(Name,ImageURL,Id)
        /// </summary>
        /// <returns></returns>
        public async Task<List<Res.Pokemon>> GetAll()
        {
            try
            {
                var pokemons = await _dbContext.Pokemons.ToListAsync();

                var result = pokemons.Select(p => new Res.Pokemon()
                {
                   Name= p.Name,
                   ImageUrl= p.ImageUrl,
                    Id=p.Id
                }).ToList();

                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
