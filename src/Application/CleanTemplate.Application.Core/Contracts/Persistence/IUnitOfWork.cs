using CleanTemplate.Domain.Core;

namespace CleanTemplate.Application.Core;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

    Task<int> Complete();

    public IAreaRepository AreaRepository { get; }

    public IEmployeeRepository EmployeeRepository { get;}

}
