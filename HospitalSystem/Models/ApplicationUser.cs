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

    public enum Gender
    {
        Female, Male, M, F
    }
}
