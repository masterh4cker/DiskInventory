using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiskInventory.Models
{
    public partial class Artist
    {
        public Artist()
        {
            DiskHasArtist = new HashSet<DiskHasArtist>();
        }

        public int ArtistId { get; set; }

        [Required(ErrorMessage = "Please enter a First Name.")]
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ArtistTypeId { get; set; }

        //[Required(ErrorMessage = "Please select an artist type.")]
        public virtual ArtistType ArtistType { get; set; }
        public virtual ICollection<DiskHasArtist> DiskHasArtist { get; set; }
    }
}
