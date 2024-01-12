namespace WebAPI.ViewModel.ReqViewModel
{
    public class AddEditUserReqViewModel
    {
        public int Id { get; set; }
        public string UserType { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; } 
        public decimal DefaultRate { get; set; }
        public string TimeZone { get; set; } 
        public string Localization { get; set; } 
        public string? GuardianName { get; set; }
        public string? GuardianPhone { get; set; }
    }
}
