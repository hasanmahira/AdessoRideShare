using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdessoRideShare.Models
{
    public class RidePlan
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public int FromId { get; set; }

        [Required]
        public int WhereId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int NumberOfSeats { get; set; }

        [Required]
        public bool IsPublished{ get; set; }

        [ForeignKey("FromId")]
        public Cities From { get; set; }

        [ForeignKey("WhereId")] 
        public Cities Where { get; set; }

    }
}
