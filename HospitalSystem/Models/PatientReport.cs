using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class PatientReport
    {
        public int Id { get; set; }

        [Required]
        public string Diagnose { get; set; }

        public ApplicationUser Doctor { get; set; }

        public ApplicationUser Patient { get; set; }    

        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }

    }
}
