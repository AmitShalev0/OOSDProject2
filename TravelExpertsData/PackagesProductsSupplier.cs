using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData;

[Table("Packages_Products_Suppliers")]
[Index("PackageId", Name = "PackagesPackages_Products_Suppliers")]
[Index("ProductSupplierId", Name = "ProductSupplierId")]
[Index("ProductSupplierId", Name = "Products_SuppliersPackages_Products_Suppliers")]
public partial class PackagesProductsSupplier
{
    public int PackageId { get; set; }

    public int ProductSupplierId { get; set; }

    [Key]
    public int PackagesProductsSuppliersId { get; set; }

    [ForeignKey("PackageId")]
    [InverseProperty("PackagesProductsSuppliers")]
    public virtual Package Package { get; set; } = null!;

    [ForeignKey("ProductSupplierId")]
    [InverseProperty("PackagesProductsSuppliers")]
    public virtual ProductsSupplier ProductSupplier { get; set; } = null!;
}
