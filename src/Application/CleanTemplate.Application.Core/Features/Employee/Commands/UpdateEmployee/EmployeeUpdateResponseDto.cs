namespace CleanTemplate.Application.Core;

public class EmployeeUpdateResponseDto
{
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public int AreaId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }    
}
