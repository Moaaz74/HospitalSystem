using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models
{
    public class PatientReport
    {
        public int Id { get; set; }

        [Required]
        public string Diagnose { get; set; }

        [ForeignKey("DoctorId")]
        public ApplicationUser Doctor { get; set; }

        [ForeignKey("PatientId")]
        public ApplicationUser Patient { get; set; }    

        public ICollection<PrescribedMedicine> PrescribedMedicines { get; set; }

    }
}
