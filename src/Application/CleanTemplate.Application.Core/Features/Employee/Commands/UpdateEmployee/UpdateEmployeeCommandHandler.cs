using AutoMapper;
using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Response<EmployeeUpdateResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;    
    }

    public async Task<Response<EmployeeUpdateResponseDto>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employeeBd = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (employeeBd is null)
        {
            throw new NotFoundException(nameof(UpdateEmployeeCommand), request.Id);
        }

        var areaBd = await _unitOfWork.AreaRepository.GetByIdAsync(request.AreaId);

        if (areaBd is null)
        {
            throw new BadRequestException("El área no existe");
        }        

        employeeBd.Name = request.Name;
        employeeBd.Email = request.Email;
        employeeBd.PhoneNumber = request.PhoneNumber;
        employeeBd.Area = areaBd;

        var resultEntity = await _unitOfWork.Repository<Employee>().UpdateAsync(employeeBd);

        if (resultEntity is null)
        {
            throw new BadRequestException("No se pudo actualizar el empleado");
        }

        var responseDto = _mapper.Map<EmployeeUpdateResponseDto>(resultEntity);


        return new Response<EmployeeUpdateResponseDto>() {
            Data = responseDto,
            Message = "Success"
        };

    }
}
