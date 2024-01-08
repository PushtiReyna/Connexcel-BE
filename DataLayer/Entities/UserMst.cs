using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserMst
{
    public int UserId { get; set; }

    public bool IsActive { get; set; }

    public bool? IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string UserType { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string EmailId { get; set; } = null!;

    public string DefaultRate { get; set; } = null!;

    public string TimeZone { get; set; } = null!;

    public string Localization { get; set; } = null!;

    public string? GuardianName { get; set; }

    public string? GuardianPhoneno { get; set; }

    public string Password { get; set; } = null!;
}
