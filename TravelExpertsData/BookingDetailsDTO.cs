using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class BookingDetailsDTO
    {
        public int BookingDetailId { get; set; }

        public double? ItineraryNo { get; set; }

        public string? RegionName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? Destination { get; set; }
    }
}
