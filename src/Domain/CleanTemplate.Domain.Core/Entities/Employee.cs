using System.ComponentModel.DataAnnotations.Schema;

namespace CleanTemplate.Domain.Core;

public class Employee : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int AreaId { get; set; }

        [ForeignKey("AreaId")]
        public Area Area { get; set; } = new Area();
    }
