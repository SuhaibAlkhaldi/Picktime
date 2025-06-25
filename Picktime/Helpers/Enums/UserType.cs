using System.ComponentModel;

namespace Picktime.Helpers.Enums
{
    public enum UserType
    {
        [Description("SystemAdmin")]
        SystemAdmin = 0,
        [Description("CategoryCreator")]
        CategoryCreator = 1,
        [Description("ProviderCreator")]
        ProviderCreator = 2,
        [Description("Client")]
        Client = 3,
    }
}
