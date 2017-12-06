using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Find_Waldo.Models
{
    public class Room
    {
        public int Id { get; set;}

        [Required]
        [Display(Name = "Cell ID: ")]
        public int CellId { get; set; }

        [Required]
        [Display(Name ="Room Name: ")]
        public string RoomName { get; set; }

        [Required]
        public int StaffId { get; set; }
        public virtual Staff Staff { get; set; }

       
        public virtual ICollection<Patient> Patients { get; set; }
    }
}