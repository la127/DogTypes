using System.ComponentModel.DataAnnotations;

namespace DogTypes.Models
{

    public class Dog
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public int BreedId { get; set; }

        public int Age { get; set; }

        public required string Color { get; set; }
    }
}
