using AutoMapper;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetListEmployeeQueryHandler : IRequestHandler<GetEmployeeListQuery, Response<List<EmployeeListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetListEmployeeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Response<List<EmployeeListDto>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
        var areas = await _unitOfWork.AreaRepository.GetAllAsync();

        var result = from tbEmployees in employees
                    join tbArea in areas on tbEmployees.AreaId equals tbArea.Id
                    select new EmployeeListDto {
                        Id = tbEmployees.Id,
                        Name = tbEmployees.Name,
                        Email = tbEmployees.Email,
                        PhoneNumber = tbEmployees.PhoneNumber,
                        AreaName = tbArea.Name,
                        CreatedDate = tbEmployees.CreatedDate,
                        LastModifiedDate = tbEmployees.LastModifiedDate,
                    };


        return new Response<List<EmployeeListDto>>() {
            Data = result.ToList(),
            Message = "Success"
        };
    }
}
