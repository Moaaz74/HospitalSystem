using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Lab
    {
        public int Id { get; set; }

        [Required]
        public int LabNumber { get; set; }

        [Required]
        public ApplicationUser Patient { get; set; }

        [Required]
        public string TestType { get; set; }

        [Required]
        public string TestCode { get; set; }

        [Required]
        public float Weigth { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public int BloodPressure { get; set; }

        [Required]
        public float Temperature { get; set;}

        [Required]
        public string TestResult { get; set; }
    }
}
