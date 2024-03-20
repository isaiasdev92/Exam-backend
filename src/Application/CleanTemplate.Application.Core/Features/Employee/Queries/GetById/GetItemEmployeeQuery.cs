using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetItemEmployeeQuery : IRequest<Response<EmployeeResponseItemDto>>
{
    public int Id { get; set; }
}
