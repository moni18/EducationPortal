using Common.Mappings;
using Microsoft.AspNetCore.Identity;

namespace Data.Entities.Models.Identity
{
    public class RoleViewModel : IMapFrom<IdentityRole>, IMapTo<IdentityRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
