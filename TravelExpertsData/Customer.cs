using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TravelExpertsData;

[Index("AgentId", Name = "EmployeesCustomers")]
public partial class Customer
{
    [Key]
    public int CustomerId { get; set; }

    [StringLength(25)]
    [Required(ErrorMessage = "First name is required.")]
    public string CustFirstName { get; set; } = null!;

    [StringLength(25)]
    [Required(ErrorMessage = "Last name is required.")]
    public string CustLastName { get; set; } = null!;

    [StringLength(75)]
    [Required(ErrorMessage = "Address is required.")]
    public string CustAddress { get; set; } = null!;

    [StringLength(50)]
    [Required(ErrorMessage = "City is required.")]
    public string CustCity { get; set; } = null!;

    [StringLength(2)]
    [Required(ErrorMessage = "Province is required.")]
    public string CustProv { get; set; } = null!;

    [StringLength(7)]
    [RegularExpression("^[A-Za-z]\\d[A-Za-z]\\d[A-Za-z]\\d$", ErrorMessage = "Postal code needs be in this format: Q1Q1Q1")]
    public string CustPostal { get; set; } = null!;

    [StringLength(25)]
    [Required(ErrorMessage = "Country is required.")]
    public string? CustCountry { get; set; }

    [StringLength(20)]
    [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a 10 digit phone number.")]
    public string? CustHomePhone { get; set; }

    [StringLength(20)]
    [Required(ErrorMessage = "Business Phone is required.")]
    [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a 10 digit phone number.")]
    public string CustBusPhone { get; set; } = null!;

    [StringLength(50)]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email.")]
    [Required(ErrorMessage = "Email is required.")]
    public string CustEmail { get; set; } = null!;

    public int? AgentId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Username is required.")]
    public string CustUserName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    [Required(ErrorMessage = "Password is required.")]
    public string CustPassword { get; set; }

    [StringLength(25)]
    [Required(ErrorMessage = "Please confirm password.")]
    [Compare("CustPassword")]
    [NotMapped]
    public string CustConfirmPassword { get; set; }

    [ForeignKey("AgentId")]
    [InverseProperty("Customers")]
    public virtual Agent? Agent { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("Customer")]
    public virtual ICollection<CreditCard> CreditCards { get; set; } = new List<CreditCard>();

    [InverseProperty("Customer")]
    public virtual ICollection<CustomersReward> CustomersRewards { get; set; } = new List<CustomersReward>();
}
