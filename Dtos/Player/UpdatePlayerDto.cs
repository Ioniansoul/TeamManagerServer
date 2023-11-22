namespace TeamManagerServer.Dtos.Player
{
    public class UpdatePlayerDto
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}