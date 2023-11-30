namespace TheSchizoGamblers.Models
{
    public class GamblersModel
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public GamblersModel(string username)
        {
            this.Username = username;
        }
    }
}
