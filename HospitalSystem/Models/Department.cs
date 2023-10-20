using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DepartmentType Type { get; set; }

        public string Description { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }
    }

    public enum DepartmentType
    {
        Cardiology , Endocrinology , Hematology , InternalMedicine , Oncology ,
        Surgery , Pediatric , ObstetricsAndGynaecology , Neurology , ENT ,
        Dentistry , Hepatology , Ophthalmologist
    }
}
