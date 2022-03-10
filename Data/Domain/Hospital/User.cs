using Data.Domain.Hospital.Base;

namespace Data.Domain.Hospital
{
    public class User : IdKeyEntityBase<int>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
