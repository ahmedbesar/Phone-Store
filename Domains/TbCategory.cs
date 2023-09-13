using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains;

public partial class TbCategory
{
    [ValidateNever]
    public int CategoryId { get; set; }
    [Required(ErrorMessage = "Please Enter Category Name")]
    public string? CategoryName { get; set; }
    [Required(ErrorMessage = "Please enter Operating System")]
    public int? OsId { get; set; }
    [ValidateNever]
    
    public string? CategoryImage { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public DateTime CreatedDate { get; set; }

    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TbO? Os { get; set; }

    public virtual ICollection<TbItem> TbItems { get; set; } = new List<TbItem>();
}
