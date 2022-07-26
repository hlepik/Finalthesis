namespace Domain.Base;

public class DomainEntityMeta : IDomainEntityMeta
{
    public string CreatedBy { get; set; } = "system";
    public DateTime CreatedAt { get; set; }
    public string UpdateBy { get; set; } = "system";
    public DateTime UpdatedAt { get; set; }
}