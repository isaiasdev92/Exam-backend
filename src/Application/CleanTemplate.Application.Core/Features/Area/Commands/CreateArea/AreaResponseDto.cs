﻿namespace CleanTemplate.Application.Core;

public class AreaResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}
