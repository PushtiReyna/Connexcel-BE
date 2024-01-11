namespace DTO.ReqDTO
{
    public class GetUserUserReqDTO
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
        public bool OrderBy { get; set; }
        public string? SearchByUserName { get; set; }
        public string? SearchByEmail { get; set; }
        public DateTime? SearchByDateRegistred { get; set; }
        public DateTime? SearchByLastLogin { get; set; }
        public string? UserType {  get; set; }
       // public string? SearchByNoOfCourses { get; set; }          
            
    }
}

