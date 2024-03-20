using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetByIdEmployeeQueryHandler : IRequestHandler<GetItemEmployeeQuery, Response<EmployeeResponseItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetByIdEmployeeQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<EmployeeResponseItemDto>> Handle(GetItemEmployeeQuery request, CancellationToken cancellationToken)
    {
        if (request.Id < 0)
        {
            throw new BadRequestException("El ID no es valido");
        }

        var employeeBd = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (employeeBd is null)
        {
            throw new NotFoundException(nameof(GetItemEmployeeQuery), request.Id);            
        }

        var areaSingle = await _unitOfWork.AreaRepository.GetByIdAsync(employeeBd.AreaId);

        if (areaSingle is null)
        {
            throw new BadRequestException("El ID de área no es valido");
        }

        var employeeResponseDto = new EmployeeResponseItemDto() 
        {
            AreaId = areaSingle.Id,
            AreaName = areaSingle.Name,
            CreatedDate = employeeBd.CreatedDate,
            Email = employeeBd.Email,
            Id = employeeBd.Id,
            LastModifiedDate = employeeBd.LastModifiedDate,
            Name = employeeBd.Name,
            PhoneNumber = employeeBd.PhoneNumber
        };

        return new Response<EmployeeResponseItemDto>() 
        {
            Data = employeeResponseDto,
            Message = "Success"
        };
    }
}
