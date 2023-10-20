using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Room Number")]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Room Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Please Choose Room Status")]
        public RoomStatus Status { get; set; }

    }

    public enum RoomStatus
    {
        Available, NotAvailable
    }
}