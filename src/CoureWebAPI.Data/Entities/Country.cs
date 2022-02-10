namespace CoureWebAPI.Data.Entities
{
    public class Country : BaseEntity
    {
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }

        //EF Relationship
        public IEnumerable<CountryDetails> CountryDetails { get; set;}
    }
}