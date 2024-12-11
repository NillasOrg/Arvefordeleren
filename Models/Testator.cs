using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Arvefordeleren.Models
{
    public class Testator
    {
        public int Id { get; set; }
        [Required (AllowEmptyStrings = false, ErrorMessage = "Navn skal udfyldes!")]
        public string? Name { get; set; } = "";

        public bool isMarried { get; set; }

        public string? Address { get; set; } = "";

        public string? Email { get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();

    }
}
