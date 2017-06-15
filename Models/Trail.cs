using System.ComponentModel.DataAnnotations;

namespace lostInTheWoods.Models
{
    public class Trail : BaseEntity {
        [Key]
        public int Id {get;set;}

        [Required]
        [MinLength(3)]
        [Display(Name = "Trail Name")]
        public string Name {get;set;}

        [Required]
        [MinLength(10)]
        public string Description {get;set;}

        [Required]
        [Display(Name = "Trail Length")]
        public double Trail_Length {get;set;}

        [Display(Name = "Elevation Change")]
        [Range(-1355,29040)]
        public long Elevation {get;set;}

        [Required]
        [Range(-180.0000,180.0000)]
        public double Longitude {get;set;}
        
        [Required]
        [Range(-90.0000,90.0000)]
        public double Latitude {get;set;}

    }
}