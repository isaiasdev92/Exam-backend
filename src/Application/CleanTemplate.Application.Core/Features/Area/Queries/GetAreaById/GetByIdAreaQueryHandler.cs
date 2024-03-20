using AutoMapper;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetByIdAreaQueryHandler : IRequestHandler<GetItemAreaQuery, Response<AreaItemDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetByIdAreaQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;    
    }

    public async Task<Response<AreaItemDto>> Handle(GetItemAreaQuery request, CancellationToken cancellationToken)
    {

        if (request.Id < 0)
        {
            throw new BadRequestException("El ID no es valido");
        }

        var areaBd = await _unitOfWork.AreaRepository.GetByIdAsync(request.Id);

        if (areaBd is null)
        {
            throw new NotFoundException(nameof(GetItemAreaQuery), request.Id);
        }

        var itemDto = _mapper.Map<AreaItemDto>(areaBd);

        return new Response<AreaItemDto>() {
            Data = itemDto
        };
    }
}
