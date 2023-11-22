namespace TeamManagerServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<List<GetTeamDto>>>> AddTeam(AddTeamDto newTeam)
        {
            return Ok(await _teamService.AddTeam(newTeam));
        } 

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTeamDto>>>> GetTeams()
        {
            return Ok(await _teamService.GetTeams());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTeamDto>>>> GetTeamById(int id)
        {
            return Ok(await _teamService.GetTeamById(id));
        }

        [HttpPut("Update")]
        public async Task<ActionResult<ServiceResponse<List<GetTeamDto>>>> UpdateTeam(UpdateTeamDto updatedTeam)
        {
            return Ok(await _teamService.UpdateTeam(updatedTeam));
        } 

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetTeamDto>>>> DeleteTeam(int id)
        {
            return Ok(await _teamService.DeleteTeam(id));
        } 

        [HttpPost("AddPlayer")]
        public async Task<ActionResult<ServiceResponse<GetTeamDto>>> AddTeamPlayer(TeamPlayerDto newTeamPlayer)
        {
            return Ok(await _teamService.AddTeamPlayer(newTeamPlayer));
        } 

        [HttpDelete("RemovePlayer")]
        public async Task<ActionResult<ServiceResponse<GetTeamDto>>> RemoveTeamPlayer(TeamPlayerDto removeTeamPlayer)
        {
            return Ok(await _teamService.RemoveTeamPlayer(removeTeamPlayer));
        } 
    }
}