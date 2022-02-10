namespace CoureWebAPI.Data.Models
{
    public class CountryResponse
    {        
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetailsResponse> CountryDetails { get; set; }
    }
}