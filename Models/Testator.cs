using System.ComponentModel.DataAnnotations;

namespace Arvefordeleren.Models
{
    public class Testator : Person
    {
        
        public string Name { get; set; }
        public bool isMarried { get; set; }

        public string? Address { get; set; }

        public string? Email { get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();

        

    }
}
