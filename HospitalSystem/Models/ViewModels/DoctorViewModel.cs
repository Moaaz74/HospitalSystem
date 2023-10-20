using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.ViewModels
{
    public class DoctorViewModel
    {
        [Required(ErrorMessage = "Pleae Enter Doctor Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Passowrd")]
        [DataType(DataType.Password , ErrorMessage = "Please Enter valid Passowrd")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Choose valid Gender")]
        public Gender Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please Enter valid Address")]
        public string Address { get; set; }

        [Required (ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.DateTime, ErrorMessage = "Please Enter a Valid Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[MinimumAge(21)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Choose Doctor Status")]
        public DoctorStatus DoctorStatus { get; set; }

        [Required(ErrorMessage = "Please Choose Doctor Specialist")]
        public Specialist Specialist { get; set; }

        [Required(ErrorMessage = "Please Choose Doctor Department")]
        public Department Department { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
