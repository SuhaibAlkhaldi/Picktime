using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class UserReviewService : SharedClass
    {
        public float Rate { get; set; }
        public string Comment { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Users { get; set; }

        [ForeignKey("ProviderServiceId")]
        public int ProviderServiceId { get; set; }
        public ProviderService ProviderServices { get; set; }

    }
}
