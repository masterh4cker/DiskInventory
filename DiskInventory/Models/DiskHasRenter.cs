using System;
using System.Collections.Generic;

namespace DiskInventory.Models
{
    public partial class DiskHasRenter
    {
        public int RenterId { get; set; }
        public int DiskId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public virtual Disk Disk { get; set; }
        public virtual Renter Renter { get; set; }
    }
}
