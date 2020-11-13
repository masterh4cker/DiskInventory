using System;
using System.Collections.Generic;

namespace DiskInventory.Models
{
    public partial class Renter
    {
        public Renter()
        {
            DiskHasRenter = new HashSet<DiskHasRenter>();
        }

        public int RenterId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNum { get; set; }

        public virtual ICollection<DiskHasRenter> DiskHasRenter { get; set; }
    }
}
