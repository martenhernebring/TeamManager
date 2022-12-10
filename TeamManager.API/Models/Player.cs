namespace TeamManager.API.Models
{
    public class Player
    {
        private string team;
        private int jersey;

        public Player(string team, int jersey)
        {
            this.team = team;
            this.jersey = jersey;
        }

        public int getJersey()
        {
            return jersey;
        }
    }
}