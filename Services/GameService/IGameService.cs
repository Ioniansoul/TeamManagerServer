namespace TeamManagerServer.Services.GameService
{
    public interface IGameService
    {
        Task<ServiceResponse<List<GetGameDto>>> AddGame(AddGameDto newGame);
        Task<ServiceResponse<List<GetGameDto>>> GetGames();
        Task<ServiceResponse<GetGameDto>> GetGameById(int id);
        Task<ServiceResponse<GetGameDto>> UpdateGame(UpdateGameDto updatedGame);
        Task<ServiceResponse<List<GetGameDto>>> DeleteGame(int id);
    }
}