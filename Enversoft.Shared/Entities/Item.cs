﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Enversoft.Shared;

public partial class Item
{
    public int ItemId { get; set; }

    public string ImageName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<OrderItem> OrderItem { get; set; } = new List<OrderItem>();
}