using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiskInventory.Models
{
    public partial class Renter
    {
        public Renter()
        {
            DiskHasRenter = new HashSet<DiskHasRenter>();
        }

        public int RenterId { get; set; }
        [Required(ErrorMessage="Please enter a First Name.")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter a Last Name.")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNum { get; set; }

        public virtual ICollection<DiskHasRenter> DiskHasRenter { get; set; }
    }
}
