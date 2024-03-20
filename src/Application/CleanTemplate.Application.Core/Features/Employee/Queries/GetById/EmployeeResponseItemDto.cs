namespace CleanTemplate.Application.Core;

public class EmployeeResponseItemDto
{
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int AreaId { get; set; }

        public string AreaName { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
}
