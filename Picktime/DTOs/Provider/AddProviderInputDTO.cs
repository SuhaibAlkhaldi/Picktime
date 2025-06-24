using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs.Provider
{
    public class AddProviderInputDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public int CategoryId { get; set; }
    }
}
