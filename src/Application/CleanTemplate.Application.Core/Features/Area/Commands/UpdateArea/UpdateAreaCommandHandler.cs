using AutoMapper;
using CleanTemplate.Domain.Core;
using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class UpdateAreaCommandHandler : IRequestHandler<UpdateAreaCommand, Response<AreaUpdateResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAreaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Response<AreaUpdateResponseDto>> Handle(UpdateAreaCommand request, CancellationToken cancellationToken)
    {
        var areaBd = await _unitOfWork.AreaRepository.GetByIdAsync(request.Id);

        if (areaBd is null)
        {
            throw new NotFoundException(nameof(UpdateAreaCommand), request.Id);
        }

        areaBd.Description = request.Description;
        areaBd.Name = request.Name;

        var resultEntity = await _unitOfWork.Repository<Area>().UpdateAsync(areaBd);

        var responseDto = _mapper.Map<AreaUpdateResponseDto>(resultEntity);

        return new Response<AreaUpdateResponseDto>() {
            Data = responseDto,            
        };
    }
}
