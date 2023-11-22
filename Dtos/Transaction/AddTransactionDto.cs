namespace TeamManagerServer.Dtos.Transaction
{
    public class AddTransactionDto
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public decimal Contribution { get; set; }
    }
}