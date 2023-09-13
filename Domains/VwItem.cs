using System;
using System.Collections.Generic;

namespace Domains;

public partial class VwItem
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public int? Area { get; set; }

    public int? Ram { get; set; }

    public string? ImageName { get; set; }

    public int? OsId { get; set; }

    public int? CategoryId { get; set; }

    public int? SalesPrice { get; set; }

    public int? PurchaisePrice { get; set; }

    public string? Description { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string? OsName { get; set; }

    public string? CategoryName { get; set; }
}
