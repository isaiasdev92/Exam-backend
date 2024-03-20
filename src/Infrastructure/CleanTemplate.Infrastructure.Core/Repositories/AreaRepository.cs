using CleanTemplate.Application.Core;
using CleanTemplate.Domain.Core;

namespace CleanTemplate.Infrastructure.Core;

public class AreaRepository : RepositoryBase<Area>, IAreaRepository
{
    public AreaRepository(CleanTemplateDbContext context) : base(context)
    {
    }
}
