namespace TeamManagerServer.Dtos.Game
{
    public class AddGameDto
    {
        public int TeamId { get; set; }   
        public DateTime Date { get; set; }
        public decimal Cost { get; set; }     
    }
}