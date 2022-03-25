using AutoMapper;

namespace BusinessLogic.Services.Education
{
    public class BaseService
    {
        protected readonly IMapper Mapper;

        public BaseService(IMapper mapper)
        {
            Mapper = mapper;
        }
    }
}
