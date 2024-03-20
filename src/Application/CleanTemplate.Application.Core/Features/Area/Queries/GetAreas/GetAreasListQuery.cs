using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetAreasListQuery : IRequest<Response<List<AreaListDto>>>
{

}
