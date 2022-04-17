using Data.Domain.Identity;


namespace Data.Domain.Education
{
    public class Student
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int? UniversityId { get; set; }
        public University University { get; set; }
        public int? SchoolId { get; set; }
        public School School { get; set; }
    }
}
