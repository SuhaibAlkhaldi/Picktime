﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.Entities
{
    public class UserReview : BaseEntity
    {
        public float Rate { get; set; }
        public string Comment { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User Users { get; set; }

        
        public int ProviderServiceId { get; set; }
        [ForeignKey("ProviderServiceId")]
        public ProviderServices ProviderServices { get; set; }

    }
}
