namespace BLL.App.DTO;

public class Category : DomainEntityId
{
    public string Name { get; set; } = default!;
    public ICollection<SubCategory>? SubCategory { get; set; }
}