using System.ComponentModel.DataAnnotations;

namespace Arvefordeleren.Models
{
    public class Person
    {
        public int Id { get; set; }
        //[Required(AllowEmptyStrings = false, ErrorMessage =("Du skal huske at indtaste et navn!"))]
        public string? Name { get; set; }
        public double Share { get; set; }
        public string? Address { get; set; }
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
