using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class PrescribedMedicine
    {
        public int Id { get; set; }

        [Required]
        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        [Required]
        public int PatientReportId { get; set; }

        public PatientReport PatientReport { get; set; }
    }
}