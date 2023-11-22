namespace TeamManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> AddPlayer(AddPlayerDto newPlayer)
        {
            return Ok(await _playerService.AddPlayer(newPlayer));
        } 

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> GetPlayers()
        {
            return Ok(await _playerService.GetPlayers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> GetPlayerById(int id)
        {
            return Ok(await _playerService.GetPlayerById(id));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            return Ok(await _playerService.UpdatePlayer(updatedPlayer));
        } 

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetPlayerDto>>>> DeletePlayer(int id)
        {
            return Ok(await _playerService.DeletePlayer(id));
        } 
    }
}