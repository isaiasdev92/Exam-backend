using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class UpdateAreaCommand : IRequest<Response<AreaUpdateResponseDto>>
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
