using PokemonApp.Models.DBModels;
using Req=PokemonApp.Models.Request;
using Res=PokemonApp.Models.Response;

namespace PokemonApp.Repository.Interface
{
    public interface IPokemonRepository
    {
        Task<bool> Add(Req.Pokemon model);
        Task<bool> Delete(int id);
        Task<List<Res.Pokemon>> GetAll();
    }
}
