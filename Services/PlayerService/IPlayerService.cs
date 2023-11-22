namespace TeamManagerServer.Services.PlayerService
{
    public interface IPlayerService
    {
        Task<ServiceResponse<List<GetPlayerDto>>> AddPlayer(AddPlayerDto newPlayer);
        Task<ServiceResponse<List<GetPlayerDto>>> GetPlayers();
        Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id);
        Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatedPlayer);
        Task<ServiceResponse<List<GetPlayerDto>>> DeletePlayer(int id);
    }
}