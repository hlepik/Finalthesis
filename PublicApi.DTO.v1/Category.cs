namespace PublicApi.DTO.v1;
public class Category
    {
        public string Name{ get; set; } = default!;
        public IEnumerable? SubCategory { get; set; }
    }
