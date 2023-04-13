using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokemonApp.Models.DBModels
{
    public class PokemonType
    {
        [Key]
        public int Id { get; set; }
        public Type Type { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}
