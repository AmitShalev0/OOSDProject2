using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertsData
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProdName { get; set; } = null!;

        public int ProductSupplierId { get; set; }

        public int? SupplierId { get; set; }

        public string? SupName { get; set; }
    }
}
