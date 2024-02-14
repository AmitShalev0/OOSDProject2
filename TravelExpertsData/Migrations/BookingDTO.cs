using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData.Migrations
{
    public class BookingDTO
    {
        [Display(Name = "Booking ID")]
        public int BookingId { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "Booking Date")]
        public DateTime? BookingDate { get; set; }

        [Display(Name = "Package Name")]
        public string PkgName { get; set; } = null!;

        [Display(Name = "Start Date")]
        [Column(TypeName = "datetime")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PkgStartDate { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? PkgEndDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string? PkgDesc { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Base Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PkgBasePrice { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Agency Commission")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? PkgAgencyCommission { get; set; }

        [Display(Name = "Travellers Count")]
        public double? TravelerCount { get; set; }
    }
}
