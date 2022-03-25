using Data.Domain.Education.Base;

namespace Data.Domain.Education
{
    public class User : IdKeyEntityBase<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
