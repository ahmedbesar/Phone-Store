using System;
using System.Collections.Generic;

namespace Domains;

public partial class TbO
{
    public int OsId { get; set; }

    public string? OsName { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int CurrentState { get; set; }

    public bool? ShowInHomePage { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<TbCategory> TbCategories { get; set; } = new List<TbCategory>();

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
