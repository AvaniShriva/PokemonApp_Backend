using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Repository.Interface;
using static PokemonApp.Helper.Helper;
using System.Xml.Linq;
using PokemonApp.Models.Request;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemon;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pokemon"></param>
        public PokemonController(IPokemonRepository pokemon)
        {
            _pokemon = pokemon;
        }

        /// <summary>
        ///  Get /api/Pokemon/getall
        ///  Create api  to get all  Pokemon data (Name,Id,Image) 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            ResponseBody res = new ResponseBody();

            try
            {
                var result = await _pokemon.GetAll();
                if (result == null)
                {
                    res.Status=false;
                 
                    res.Message="Data not Found!";
                    res.StatusCode =  System.Net.HttpStatusCode.NoContent;
                }
                else
                {
                    res.Status=true;
                    res.Data= result;
                    res.Message="Data Found !";
                    res.StatusCode =  System.Net.HttpStatusCode.OK;
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }
        }

        /// <summary>
        ///  Post /api/Pokemon/add
        ///  Create API to Add data in database
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Pokemon PokemonTables)
        {
            ResponseBody res = new ResponseBody();
            try
            {
                var result = await _pokemon.Add(PokemonTables);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest("failed");
            }
        }
        /// <summary>
        ///  Post /api/Pokemon/delete
        ///   API to Delete data in database
        /// </summary>
        /// <returns></returns>

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pokemon.Delete(id);
            return Ok(result);
        }
    }
}
