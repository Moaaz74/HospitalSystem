using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
    
        
        public string Description { get; set; } 


        public ApplicationUser Doctor { get; set; }


        public ApplicationUser Patient { get; set; }
    }
}