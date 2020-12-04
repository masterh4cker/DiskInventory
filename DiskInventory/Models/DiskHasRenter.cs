using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiskInventory.Models
{
    public partial class DiskHasRenter
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a borrower")]
        public int RenterId { get; set; }
        public virtual Renter Renter { get; set; }

        [Required(ErrorMessage = "Please enter a disk.")]
        public int DiskId { get; set; }
        public virtual Disk Disk { get; set; }

        [Required(ErrorMessage = "Please enter a borrowed date.")]
        public DateTime RentDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

      
    
    }
}
