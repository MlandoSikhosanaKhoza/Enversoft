﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Enversoft.Shared;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}