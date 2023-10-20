using HospitalSystem.Models.Validation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models
{
    public enum Gender
    {
        Female, Male, M, F
    }

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(30, ErrorMessage = "Name Length must be between 3 an 30 characters", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Please Enter a Valid Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[MinimumAge(21)]
        public DateTime DOB { get; set; }

        public Department Department { get; set; }

        public Specialist Specialist { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public DoctorStatus DoctorStatus { get; set; }

    }

    public enum DoctorStatus
    {
        Active , NonActive , inOperatingRoom, NotAvailable, onLeave
    }

    public enum Specialist
    {
        Internist , ophthalmologist , Otorhinolaryngologist , 
        neurologist , Cardiovascular , Dermatologist , Radiologist  ,
        Pediatrician , Surgeon , Neonatologist , Oncologist , EmergencyPhysician , Dentist
    }
}
