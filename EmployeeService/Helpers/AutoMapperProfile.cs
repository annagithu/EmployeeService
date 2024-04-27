using AutoMapper;
using EmployeeService.InternalContracts.Models;

namespace EmployeeService.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeQueryModel, EmployeeModel>();
        }
    }
}
