using System;
using System.Collections.Generic;

namespace Domains;

public partial class VwCategory
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public int? OsId { get; set; }

    public string? CategoryImage { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? OsName { get; set; }
}
