using System;
using System.Collections.Generic;

namespace Nnt_TvcLesson12.Models;

public partial class NntProduct
{
    public int NntId { get; set; }

    public string? NntName { get; set; }

    public string? NntImage { get; set; }

    public decimal? NntPrice { get; set; }

    public decimal? NntSalePrice { get; set; }

    public int? NntStatus { get; set; }

    public string? NntDescriptions { get; set; }

    public DateTime? NntCreatedDate { get; set; }

    public int? NntCategoryId { get; set; }
}
