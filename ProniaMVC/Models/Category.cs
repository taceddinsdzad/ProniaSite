using ProniaMVC.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ProniaMVC.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(30, ErrorMessage = "30 dan yuxar olmaz")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }

    }
}
