using System.ComponentModel.DataAnnotations;

namespace DogTypes.Models
{
    public class Breed
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Origin { get; set; }

        public required string Size { get; set; }

        public required string Temperament { get; set; }
    }
}
