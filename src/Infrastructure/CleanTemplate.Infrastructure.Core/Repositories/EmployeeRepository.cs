using CleanTemplate.Application.Core;
using CleanTemplate.Domain.Core;

namespace CleanTemplate.Infrastructure.Core;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(CleanTemplateDbContext context) : base(context)
    {
    }
}
