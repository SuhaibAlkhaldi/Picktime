using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class Provider : SharedClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public ICollection<UserReviewService> Reviews { get; set; }

        public ICollection<ProviderService> ProviderServices { get; set; }

       
    }
}
