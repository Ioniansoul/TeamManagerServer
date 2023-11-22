namespace TeamManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService GameService)
        {
            _gameService = GameService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> AddGame(AddGameDto newGame)
        {
            return Ok(await _gameService.AddGame(newGame));
        } 

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> GetGames()
        {
            return Ok(await _gameService.GetGames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> GetGameById(int id)
        {
            return Ok(await _gameService.GetGameById(id));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> UpdateGame(UpdateGameDto updatedGame)
        {
            return Ok(await _gameService.UpdateGame(updatedGame));
        } 

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetGameDto>>>> DeleteGame(int id)
        {
            return Ok(await _gameService.DeleteGame(id));
        } 
    }
}