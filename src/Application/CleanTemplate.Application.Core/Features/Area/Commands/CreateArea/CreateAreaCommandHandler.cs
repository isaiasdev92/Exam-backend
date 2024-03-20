using AutoMapper;
using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, Response<AreaResponseDto>>
{
    private readonly IAppLogger<CreateAreaCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CreateAreaCommandHandler(IAppLogger<CreateAreaCommandHandler> logger, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task<Response<AreaResponseDto>> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
    {
        var areaEntity = _mapper.Map<Area>(request);

        var resultEntity = await _unitOfWork.Repository<Area>().AddAsync(areaEntity);


        if (resultEntity is null)
        {
            _logger.LogError(null, "No se inserto el record de la área");
            throw new Exception("No se pudo insertar el record del área");
        }

        var entityDto = _mapper.Map<AreaResponseDto>(resultEntity);

        return new Response<AreaResponseDto>()
        {
            Data = entityDto,
            Message = "Success"
        };
    }
}
