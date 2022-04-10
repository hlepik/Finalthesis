namespace Domain.App;

public class SubCategory : DomainEntityId
{
    [MinLength(2)]
    [MaxLength(500)]

    public string Name { get; set; } = default!;

 
}