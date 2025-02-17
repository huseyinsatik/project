using System.ComponentModel.DataAnnotations;

namespace project.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Car Make")]
        public string CarMake { get; set; }

        [Required]
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }

        [Required]
        [Display(Name = "Car Year")]
        [Range(1900, 2024)]
        public int CarYear { get; set; }

        [Required]
        [Display(Name = "Number of Speeding Tickets")]
        [Range(0, int.MaxValue)]
        public int SpeedingTickets { get; set; }

        [Required]
        [Display(Name = "Has DUI")]
        public bool HasDUI { get; set; }

        [Required]
        [Display(Name = "Full Coverage")]
        public bool IsFullCoverage { get; set; }

        [Display(Name = "Monthly Quote")]
        public decimal Quote { get; set; }
    }
} 