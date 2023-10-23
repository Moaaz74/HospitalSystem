using HospitalSystem.Models.Validation;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalSystem.Models
{

    public class ApplicationUser : IdentityUser
    {

        public Gender Gender { get; set; }

        public string Nationality { get; set; }

        public string Address { get; set; }

        public DateTime DOB { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public Specialist Specialist { get; set; }

        [InverseProperty("Doctor")]
        public ICollection<Appointment> DoctorAppointments { get; set; }

        [InverseProperty("Patient")]
        public ICollection<Appointment> PatientAppointment { get; set; }

        public DoctorStatus DoctorStatus { get; set; }

        [Required]
        public short Discriminator { get; set; }

        [InverseProperty("Doctor")]
        public PatientReport DoctorReport { get; set; }

        [InverseProperty("Patient")]
        public ICollection<PatientReport> PatientReports { get; set; }

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

    public enum Gender
    {
        Female, Male
    }
}
