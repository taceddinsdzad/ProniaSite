using ProniaMVC.Models.Base;

namespace ProniaMVC.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        List<Product> products { get; set; }

    }
}
