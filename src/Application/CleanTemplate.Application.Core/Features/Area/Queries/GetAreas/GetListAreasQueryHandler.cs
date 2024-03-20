using AutoMapper;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetListAreasQueryHandler : IRequestHandler<GetAreasListQuery, Response<List<AreaListDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public GetListAreasQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<Response<List<AreaListDto>>> Handle(GetAreasListQuery request, CancellationToken cancellationToken)
    {
        var areas = await _unitOfWork.AreaRepository.GetAllAsync();

        var areasDto = _mapper.Map<List<AreaListDto>>(areas);

        return new Response<List<AreaListDto>>() {
            Data = areasDto
        };
    }
}
