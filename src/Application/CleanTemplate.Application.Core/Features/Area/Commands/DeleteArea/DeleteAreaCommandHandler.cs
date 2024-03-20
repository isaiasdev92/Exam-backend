using AutoMapper;
using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class DeleteAreaCommandHandler : IRequestHandler<DeleteAreaCommand, Response<bool>>
{
    private readonly IUnitOfWork _unitOfwork;

    public DeleteAreaCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfwork = unitOfWork;
    }

    public async Task<Response<bool>> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
    {
        if (request.Id < 0)
        {
            throw new BadRequestException("El valor ID no es valido");
        }

        var areaItem = await _unitOfwork.AreaRepository.GetByIdAsync(request.Id);

        if (areaItem is null )
        {
            throw new NotFoundException(nameof(Area), request.Id);
        }

        await _unitOfwork.AreaRepository.DeleteAsync(areaItem);
        
        return new Response<bool>() {
            Data = true
        };
    }
}
