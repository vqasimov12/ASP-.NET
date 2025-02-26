﻿using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Models;
public class ShippingDetails
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    public required string City { get; set; }
    public required string Address { get; set; }
    [Range(15,75)]
    public required short Age { get; set; }
}