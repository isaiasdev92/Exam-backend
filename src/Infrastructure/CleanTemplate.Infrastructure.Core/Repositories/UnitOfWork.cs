using System.Collections;
using CleanTemplate.Application.Core;
using CleanTemplate.Domain.Core;

namespace CleanTemplate.Infrastructure.Core;

public class UnitOfWork : IUnitOfWork
{   
    private Hashtable? _repositories;
    private readonly CleanTemplateDbContext _context;

    private IAreaRepository? _areaRepository;
    private IEmployeeRepository? _employeeRepository;

    public CleanTemplateDbContext CleanTemplateDbContext => _context;

    public IAreaRepository AreaRepository => _areaRepository ??= new AreaRepository(_context);
    public IEmployeeRepository EmployeeRepository => _employeeRepository ??= new EmployeeRepository(_context);

    public UnitOfWork(CleanTemplateDbContext context)
    {
        _context = context;
    }
    public async Task<int> Complete()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {            
            throw new DatabaseException($"Error to save: {ex.Message}");
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
    {
            if (_repositories == null)
            { 
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
    }
}
