using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class CreateAreaCommand : IRequest<Response<AreaResponseDto>>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
