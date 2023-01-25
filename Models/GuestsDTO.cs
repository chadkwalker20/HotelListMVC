using System.ComponentModel.DataAnnotations;

namespace HotelListMVC.Models
{
    public class GuestsDTO
    {
        public int Id { get; set; }


        [Required, RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Display(Name = "First Name")]
        public string? FirstName { get; set; }


        [Required, RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$"), Display(Name = "Last Name")]
        public string? LastName { get; set; }


        [Required, RegularExpression("^((\\(\\d{3}\\))|\\d{3})[-]?\\d{3}[- ]?\\d{4}$"), StringLength(12, MinimumLength = 10)]
        [Display(Name = "Phone Number")]
        public string? PhoneNum { get; set; }


        [Required, Display(Name = "Check In Date"), DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }


        [Required, Display(Name = "Check Out Date"), DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }


    }
}
