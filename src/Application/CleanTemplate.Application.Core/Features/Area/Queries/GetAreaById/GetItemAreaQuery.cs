using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetItemAreaQuery : IRequest<Response<AreaItemDto>>
{
    public int Id { get; set; }
}
