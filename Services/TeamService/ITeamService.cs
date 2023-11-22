namespace TeamManagerServer.Services.TeamService
{
    public interface ITeamService
    {
        Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newTeam);
        Task<ServiceResponse<List<GetTeamDto>>> GetTeams();
        Task<ServiceResponse<GetTeamDto>> GetTeamById(int id);
        Task<ServiceResponse<GetTeamDto>> UpdateTeam(UpdateTeamDto updatedTeam);
        Task<ServiceResponse<List<GetTeamDto>>> DeleteTeam(int id);
        Task<ServiceResponse<GetTeamDto>> AddTeamPlayer(TeamPlayerDto newTeamPlayer);
        Task<ServiceResponse<GetTeamDto>> RemoveTeamPlayer(TeamPlayerDto removeTeamPlayer);
    }
}