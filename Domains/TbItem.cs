using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domains;

public partial class TbItem
{
    [ValidateNever]
    public int ItemId { get; set; }
    [Required(ErrorMessage = "Please enter item name")]
    public string? ItemName { get; set; }
    [Required(ErrorMessage = "Please enter Storage Space")]
    [Range(1, 2000, ErrorMessage = "please enter Storage Space in ragne")]
    public int? Area { get; set; }
    [Required(ErrorMessage = "Please enter ram size")]
    [Range(1, 500, ErrorMessage = "please enter ram in ragne")]
    public int? Ram { get; set; }

    public string? ImageName { get; set; }
    [Required(ErrorMessage = "Please enter Operating System")]
    public int? OsId { get; set; }
    [Required(ErrorMessage = "Please enter category")]
    public int? CategoryId { get; set; }
    [Required(ErrorMessage = "Please enter Sales price")]
    [DataType(DataType.Currency, ErrorMessage = "please enter currency")]
    [Range(50, 100000, ErrorMessage = "pelase enter price in system range")]
    public int? SalesPrice { get; set; }
    [Required(ErrorMessage = "Please enter Purchase price")]
    [DataType(DataType.Currency, ErrorMessage = "please enter currency")]
    [Range(50, 100000, ErrorMessage = "pelase enter price in system range")]
    public int? PurchaisePrice { get; set; }
    [Required(ErrorMessage = "Please enter Purchase description")]
    public string? Description { get; set; }
    [ValidateNever]
    public string CreatedBy { get; set; } = null!;
    [ValidateNever]
    public DateTime CreatedDate { get; set; }
    [ValidateNever]
    public int CurrentState { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
    [ValidateNever]
    public virtual TbCategory? Category { get; set; }
    [ValidateNever]
    public virtual TbO? Os { get; set; }
}
