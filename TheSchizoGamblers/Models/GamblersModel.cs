namespace TheSchizoGamblers.Models
{
    public class GamblersModel
    {
        public Guid ID { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
