﻿namespace CleanTemplate.Application.Core;

public class EmployeeResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public int AreaId { get; set; }
}
