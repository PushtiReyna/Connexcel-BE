using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class TutorOfferingDetail
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public int TutorId { get; set; }

    public string Subject { get; set; } = null!;

    public string AgeGroup { get; set; } = null!;

    public string HourlyRate { get; set; } = null!;
}
