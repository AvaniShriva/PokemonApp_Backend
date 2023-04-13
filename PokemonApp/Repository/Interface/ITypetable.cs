using PokemonApp.Models.DBModels;

namespace PokemonApp.Repository.Interface
{
    public interface ITypetable
    {
        Task<bool> AddType(Models.DBModels.Type TypeTables);
        Task<List<Models.DBModels.Type>> GetData();
        Task<bool> DeleteType(int id);
        Task<bool> UpdateType(Models.DBModels.Type TypeTables);
        Task<Models.DBModels.Type> GetTypeById(int Id);
    }
}
