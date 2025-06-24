using Picktime.DTOs.Provider;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Provider : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<UserReview> Reviews { get; set; }

        public ICollection<ProviderServices> ProviderServices { get; set; }


        
    }
}
