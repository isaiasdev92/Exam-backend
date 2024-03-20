using AutoMapper;
using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<EmployeeResponseDto>>
{

    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;


    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<EmployeeResponseDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {

        var areaExist = await _unitOfWork.AreaRepository.GetByIdAsync(request.AreaId);

        if (areaExist is null)
        {
            throw new BadRequestException("El área no existe");
        }
        
        var employeeEntity = _mapper.Map<Employee>(request);

        employeeEntity.Area = areaExist;

        var resultEntity = await _unitOfWork.Repository<Employee>().AddAsync(employeeEntity);

        if (resultEntity is null)
        {
            throw new Exception("No se pudo insertar el record del empleado");
        }

        var entityDto = _mapper.Map<EmployeeResponseDto>(resultEntity);

        return new Response<EmployeeResponseDto>() {
            Data = entityDto,
            Message = "Success"
        };
    }
}
