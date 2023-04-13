using System.ComponentModel.DataAnnotations;

namespace PokemonApp.Models.DBModels
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        public string TypeName { get; set; }=string.Empty;
    }
}
