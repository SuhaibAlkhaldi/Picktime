using System.ComponentModel;

namespace Picktime.Heplers.Enums
{
    public enum UserType
    {
        [Description("System Admin")]
        SystemAdmin = 0,
        [Description("Category Creator")]
        CategoryCreator = 1,
        [Description("Provider Creator")]
        ProviderCreator = 2,
        [Description("Client")]
        Client = 3,
    }
}
