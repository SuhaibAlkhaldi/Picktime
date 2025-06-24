using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs.Review
{
    public class CreateReviewDTO
    {
        public float Rate { get; set; } // 1,2,3,4,5
        public string Comment { get; set; }

        //public int UserId { get; set; } //from token

        public int ProviderServiceId { get; set; } 

    }
}
