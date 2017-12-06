using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Find_Waldo.Models
{
    public class Patient
    {
        public int Id { get; set; }


        [Required]
        public string MRN { get; set; }

        [Required]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth: ")]
        public string DOB { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact: ")]
        public string Contact { get; set; }

        [Required]
        public string Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public int CellId { get; set; }
        public virtual Room Rooms { get; set; }
    }
}