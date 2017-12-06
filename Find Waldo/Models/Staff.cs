using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Find_Waldo.Models
{
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        [Column(TypeName ="varchar")]
        [RegularExpression(@"\d{6,10}", ErrorMessage ="Staff # must be between 6 and 10 digits.")]
        [Display(Name = "Staff #")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //Reference user that holds this account, supports lazy loading of this object. 
        public virtual ApplicationUser User { get; set; }

        //assign user ID
        [Required]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }

}