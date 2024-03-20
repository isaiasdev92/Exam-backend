using AutoMapper;
using CleanTemplate.Domain.Core;

namespace CleanTemplate.Application.Core;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateAreaCommand, Area>();
        CreateMap<Area, AreaResponseDto>();

        CreateMap<UpdateAreaCommand, Area>();
        CreateMap<Area, AreaUpdateResponseDto>();

        CreateMap<Area, AreaListDto>();
        CreateMap<Area, AreaItemDto>();

        CreateMap<CreateEmployeeCommand, Employee>();
        CreateMap<Employee, EmployeeResponseDto>();

        CreateMap<Employee, EmployeeUpdateResponseDto>();

        CreateMap<Employee, EmployeeListDto>();
        CreateMap<Employee, EmployeeResponseItemDto>();
    }
}
