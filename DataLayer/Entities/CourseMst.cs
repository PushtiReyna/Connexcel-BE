using System;
using System.Collections.Generic;

namespace DataLayer.Entities;

public partial class CourseMst
{
    public int Id { get; set; }

    public bool IsActive { get; set; }

    public bool IsDelete { get; set; }

    public int CreatedBy { get; set; }

    public int UpdatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }

    public string CourseType { get; set; } = null!;

    public string NoofLessons { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal StudentDefaultRate { get; set; }

    public string CourseName { get; set; } = null!;

    public string Frequency { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Tutors { get; set; } = null!;

    public string? CourseStatus { get; set; }

    public string? CourseConversion { get; set; }
}
