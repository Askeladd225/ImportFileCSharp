using System.ComponentModel.DataAnnotations;

namespace ImportFile.WebApi.Core.Domain
{
    public class Game
    {

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Plateforme { get; set; } = null!;
       public string Genre { get; set; } = null!;

    }
}