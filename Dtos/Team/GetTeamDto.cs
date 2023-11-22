namespace TeamManagerServer.Dtos.Team
{
    public class GetTeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public List<GetPlayerDto>? Players { get; set; }
    }
}