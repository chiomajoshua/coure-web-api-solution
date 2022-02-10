namespace CoureWebAPI.Data.Entities
{
    public class CountryDetails : BaseEntity
    {
        public string Operator { get; set; }
        public string OperatorCode { get; set; }
        public int CountryId { get; set; }

        //EF Relationship
        public Country Country { get; set; }
    }
}