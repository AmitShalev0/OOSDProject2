using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class PackagesDTO
    {
        [Display(Name = "Package ID")]
        public int PackageId { get; set; }

        [Display(Name = "Package Name")]
        public string PkgName { get; set; } = null!;

        [Display(Name = "Start Date")]
        [Column(TypeName = "datetime")]
        public DateTime? PkgStartDate { get; set; }

        [Column(TypeName = "datetime")]
        [Display(Name = "End Date")]
        public DateTime? PkgEndDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string? PkgDesc { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Base Price")]
        public decimal PkgBasePrice { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Agency Commission")]
        public decimal? PkgAgencyCommission { get; set; }
    }
}
