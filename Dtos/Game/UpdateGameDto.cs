namespace TeamManagerServer.Dtos.Game
{
    public class UpdateGameDto
    {
        public int GameId { get; set; }
        public int TeamId { get; set; }    
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }     
    }
}