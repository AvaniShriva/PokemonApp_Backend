using Microsoft.EntityFrameworkCore;
using PokemonApp.Data;
using PokemonApp.Models.DBModels;
using PokemonApp.Repository.Interface;
using static PokemonApp.Helper.Helper;

namespace PokemonApp.Repository.Service
{
    public class TypeTabledata : ITypetable
    {
        private readonly ApplicationdbContext db;

        public TypeTabledata(ApplicationdbContext data)
        {
            db=data;
        }
        public async Task<bool> AddType(Models.DBModels.Type TypeTables)
        {
            ResponseBody res = new ResponseBody();
            try
            {
                Models.DBModels.Type obj = new Models.DBModels.Type();
                obj.TypeName = TypeTables.TypeName;

                await db.TypeTables.AddAsync(obj);
                int a = await db.SaveChangesAsync();
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteType(int id)
        {
            try
            {
                var obj = await db.TypeTables.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (obj != null)
                {

                    db.TypeTables.Remove(obj);
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Models.DBModels.Type> GetTypeById(int Id)
        {
            try
            {
                var obj = await db.TypeTables.Where(x => x.Id == Id).FirstOrDefaultAsync();
                if (obj != null)
                {
                    return obj;
                }
                else { return null; }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Models.DBModels.Type>> GetData()
        {
            try
            {
                var data = await db.TypeTables.ToListAsync();

                return data;


            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateType(Models.DBModels.Type TypeTables)
        {
            try
            {
                var Data = await db.TypeTables.Where(x => x.Id == TypeTables.Id).FirstOrDefaultAsync();
                if (Data != null)
                {
                    Data.TypeName= TypeTables.TypeName;

                    db.Entry(Data).State = EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
