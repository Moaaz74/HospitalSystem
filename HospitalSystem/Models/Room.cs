using System.ComponentModel.DataAnnotations;

namespace HospitalSystem.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public RoomStatus Status { get; set; }

    }

    public enum RoomStatus
    {
        Available, NotAvailable
    }
}