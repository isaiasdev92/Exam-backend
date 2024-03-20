using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class DeleteAreaCommand : IRequest<Response<bool>>
{
    public int Id { get; set; }
}
