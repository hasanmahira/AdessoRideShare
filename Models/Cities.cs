using System.ComponentModel.DataAnnotations;

namespace AdessoRideShare.Models
{
    public class Cities 
    {

        [Required]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public int Longitude { get; set; }

        [Required]
        public int Latitude { get; set; }
    }
}
