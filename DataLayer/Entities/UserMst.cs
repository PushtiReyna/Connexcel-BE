using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class UserMst
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string UserType { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal DefaultRate { get; set; }

    public string TimeZone { get; set; } = null!;

    public string Localization { get; set; } = null!;

    public string? GuardianName { get; set; }

    public string? GuardianPhone { get; set; }

    public string Password { get; set; } = null!;

    public string SchoolYearGroup { get; set; } = null!;

    public DateTime DateofBirth { get; set; }

    public string School { get; set; } = null!;

    public string UseableHours { get; set; } = null!;

    public string HourlyRate { get; set; } = null!;

    public string PlatformPreference { get; set; } = null!;

    public string? PlatformLink { get; set; }

    public DateTime LastLogin { get; set; }
}
