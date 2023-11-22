namespace TeamManagerServer.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public int TeamId { get; set; }    
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }      
        public List<Transaction>? Transactions { get; set; }
    }
}