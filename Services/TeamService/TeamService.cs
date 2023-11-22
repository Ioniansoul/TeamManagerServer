namespace TeamManagerServer.Services.TeamService
{
    public class TeamService : ITeamService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TeamService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> AddTeam(AddTeamDto newTeam)
        {
            var serviceResponse = new ServiceResponse<List<GetTeamDto>>();

            var team = _mapper.Map<Team>(newTeam);
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Teams
                .Include(c => c.Players)
                .Select(c => _mapper.Map<GetTeamDto>(c))
                .ToListAsync();

            return serviceResponse;                
        }

        public async Task<ServiceResponse<GetTeamDto>> AddTeamPlayer(TeamPlayerDto newTeamPlayer)
        {
            var serviceResponse = new ServiceResponse<GetTeamDto>();

            try
            {
                var team = 
                    await _context.Teams
                    .Include(c => c.Players)
                    .FirstOrDefaultAsync(c => c.TeamId == newTeamPlayer.TeamId);

                if(team is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                    return serviceResponse;
                }

                var player = 
                    await _context.Players
                    .FirstOrDefaultAsync(c => c.PlayerId == newTeamPlayer.PlayerId);

                if(player is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player not found.";
                    return serviceResponse; 
                }

                if(team.Players!.Contains(player))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player already added.";
                    return serviceResponse; 
                }

                team.Players!.Add(player);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTeamDto>(team);               
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> DeleteTeam(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            
            try
            { 
                var team =
                    await _context.Teams
                    .FirstOrDefaultAsync(c => c.TeamId == id);

                if(team is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                    return serviceResponse;
                }

                _context.Teams.Remove(team);
                await _context.SaveChangesAsync();    

                serviceResponse.Data = 
                    await _context.Teams
                    .Include(c => c.Players)
                    .Select(c => _mapper.Map<GetTeamDto>(c))
                    .ToListAsync();       
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> GetTeamById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTeamDto>();
            
            try
            {
                var team =
                    await _context.Teams
                    .Include(c => c.Players)
                    .FirstOrDefaultAsync(c => c.TeamId == id);

                if(team is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<GetTeamDto>(team);  
            }   

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTeamDto>>> GetTeams()
        {
            var serviceResponse = new ServiceResponse<List<GetTeamDto>>();
            
            var teams =
                await _context.Teams
                .Include(c => c.Players)
                .Select(c => _mapper.Map<GetTeamDto>(c))
                .ToListAsync();
            
            if(teams.Count == 0)
            {
                serviceResponse.Message = "No teams found.";
            }

            serviceResponse.Data = teams;                
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> RemoveTeamPlayer(TeamPlayerDto removeTeamPlayer)
        {
            var serviceResponse = new ServiceResponse<GetTeamDto>();

            try
            {
                var team = 
                    await _context.Teams
                    .Include(c => c.Players)
                    .FirstOrDefaultAsync(c => c.TeamId == removeTeamPlayer.TeamId);

                if(team is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                    return serviceResponse;
                }

                var player = 
                    await _context.Players
                    .FirstOrDefaultAsync(c => c.PlayerId == removeTeamPlayer.PlayerId);

                if(player is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player not found.";
                    return serviceResponse; 
                }

                if(!team.Players!.Contains(player))
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player not found.";
                    return serviceResponse; 
                }

                team.Players!.Remove(player);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTeamDto>(team);               
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTeamDto>> UpdateTeam(UpdateTeamDto updatedTeam)
        {
            var serviceResponse = new ServiceResponse<GetTeamDto>();     

            try
            {            
                var team = 
                    await _context.Teams
                    .Include(c => c.Players)
                    .FirstOrDefaultAsync(c => c.TeamId == updatedTeam.TeamId);

                if(team is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                }  

                _mapper.Map(updatedTeam, team);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTeamDto>(team);    
            }      

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}