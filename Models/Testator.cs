namespace Arvefordeleren.Models
{
    public class Testator : Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isMarried { get; set; }

        public string? Address { get; set; } = "";

        public string? Email { get; set; }
        public double Share { get; set; }

        public List<Heir> Heirs { get; set; } = new List<Heir>();

    }
}
