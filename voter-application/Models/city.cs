namespace voter_application.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign key relationship
        public int StateId { get; set; }
        public State State { get; set; }
    }
}