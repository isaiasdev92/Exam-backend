namespace CleanTemplate.Domain.Core;

    public class Area : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
