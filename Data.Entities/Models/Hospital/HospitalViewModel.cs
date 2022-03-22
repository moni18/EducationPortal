using Common.Mappings;
using Data.Entities.Domain.Base;

namespace Data.Entities.Models.Hospital
{
    public class HospitalViewModel : NameKeyEntityBase<int>, IMapFrom<Domain.Hospital.Hospital>, IMapTo<Domain.Hospital.Hospital>
    {
    }
}
