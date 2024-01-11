namespace WebAPI.ViewModel.ResViewModel
{
    public class GetUserUserResViewModel
    {
        public int TotalCount { get; set; }
        public List<UserList> UserLists { get; set; }
    }
    public class UserList
    {
        public int Id { get; set; }
        public DateTime DateRegistred { get; set; }
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
      //  public int NumberOfCourses { get; set; }
        public DateTime? LastLogin { get; set; }
        public string Status { get; set; }

    }
}

