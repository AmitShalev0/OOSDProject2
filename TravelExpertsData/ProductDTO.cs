using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProdName { get; set; } = null!;

        public int ProductSupplierId { get; set; }

        public int? SupplierId { get; set; }

        [Display(Name = "Supplier Name")]
        public string? SupName { get; set; }
    }
}
