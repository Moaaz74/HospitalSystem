using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models.ViewModels
{
    public class PatientViewModel
    {
        [Required(ErrorMessage = "Pleae Enter Patient Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Patient Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Passowrd")]
        [DataType(DataType.Password, ErrorMessage = "Please Enter valid Passowrd")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Choose Gender")]
        public Gender Gender { get; set; }

        [Required]
        public string Nationality { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.DateTime, ErrorMessage = "Please Enter a Valid Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[MinimumAge(21)]
        public DateTime DOB { get; set; }
    }
}
