namespace TeamManagerServer.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<Team>? Teams { get; set; }
        public List<Transaction>? Transactions { get; set; }
    }
}