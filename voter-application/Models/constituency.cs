namespace voter_application.Models
{
    public class Constituency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key relationship
        public int CityId { get; set; }
        public City City { get; set; }
    }
}