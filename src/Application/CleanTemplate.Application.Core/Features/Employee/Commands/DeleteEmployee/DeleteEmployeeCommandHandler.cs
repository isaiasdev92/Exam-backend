using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Response<bool>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 0)
        {
            throw new BadRequestException("El valor ID no es valido");
            
        }

        var employeeItem = await _unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);

        if (employeeItem is null)
        {
            throw new NotFoundException(nameof(Employee), request.Id);
            
        }

        await _unitOfWork.EmployeeRepository.DeleteAsync(employeeItem);


        return new Response<bool>() {
            Data = true
        };
    }
}
