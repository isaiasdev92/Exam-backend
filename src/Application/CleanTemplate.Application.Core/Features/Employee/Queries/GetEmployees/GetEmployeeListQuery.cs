using CleanTemplate.Transversal.Core;
using MediatR;

namespace CleanTemplate.Application.Core;

public class GetEmployeeListQuery : IRequest<Response<List<EmployeeListDto>>>
{
    
}
