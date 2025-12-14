using System;
using System.Collections.Generic;

namespace EmployeeEntiry.Models;

public partial class TblEmployee
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }
}
