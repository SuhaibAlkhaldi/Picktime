﻿namespace Picktime.DTOs.Provider
{
    public class UpdateProviderInputDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
        public int? CategoryId { get; set; }
    }
}
