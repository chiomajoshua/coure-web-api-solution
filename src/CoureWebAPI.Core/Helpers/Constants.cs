namespace CoureWebAPI.Core.Helpers
{
    public static class Constants
    {
        public static string GetCountryCode(string phoneNumber) => phoneNumber[..3];
    }
}