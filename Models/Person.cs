using System.ComponentModel.DataAnnotations;

namespace Arvefordeleren.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = ("Navn er påkrævet!"))]
        public string? Name { get; set; }
        public double Share { get; set; }     
        public RelationType? Relation { get; set; }

        public string? Icon
        {
            get
            {
                switch (Relation)
                {
                    case RelationType.Barn:
                        return "/images/Barn.png";

                    case RelationType.Barnebarn:
                        return "/images/Barnebarn.png";

                    case RelationType.Forældre:
                        return "/images/Forældre.png";

                    default:
                        return "/images/Andet.png";
                }
            }
        }
    }
}
