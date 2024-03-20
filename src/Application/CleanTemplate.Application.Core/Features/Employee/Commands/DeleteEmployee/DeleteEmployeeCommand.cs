using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class DeleteEmployeeCommand : IRequest<Response<bool>>
{
    public int Id { get; set; }
}
