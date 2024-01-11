namespace WebAPI.ViewModel.ReqViewModel
{
    public class UpdateStudentReqViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string TimeZone { get; set; } = null!;
        public string Email { get; set; }
        public string? SchoolYearGroup { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string? School { get; set; }
        public string? UseableHours { get; set; }
        public string? HourlyRate { get; set; }
    }
}
