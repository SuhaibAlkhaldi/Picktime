﻿using Picktime.Helpers.Enums;

namespace Picktime.DTOs.Provider
{
    public class RequestCalculateAverageServiceTimeDTO
    {
        public int providerId { set; get; }
        public EServicesActions Status { get; set; }
    }
}
