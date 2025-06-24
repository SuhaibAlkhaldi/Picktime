using Picktime.DTOs.Category;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Icon {  get; set; }
        public ICollection<Provider> ServiceProviders { get; set; }
      
    }
}
