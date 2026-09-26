using System;
using System.Collections.Generic;

namespace NguyenNhuToi2410900075_exam.Models;

public partial class NntMember
{
    public long Id { get; set; }

    public string? NntName { get; set; }

    public string? NntGender { get; set; }

    public DateOnly? NntBirthDay { get; set; }

    public string? NntEmail { get; set; }

    public string? NntPhone { get; set; }

    public bool? NntActive { get; set; }
}
