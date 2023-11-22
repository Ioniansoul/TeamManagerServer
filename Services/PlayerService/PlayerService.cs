namespace TeamManagerServer.Services.PlayerService
{
    public class PlayerService : IPlayerService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PlayerService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<ServiceResponse<List<GetPlayerDto>>> AddPlayer(AddPlayerDto newPlayer)
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();

            var player = _mapper.Map<Player>(newPlayer);
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            serviceResponse.Data = 
                await _context.Players
                .Select(c => _mapper.Map<GetPlayerDto>(c))
                .ToListAsync();
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> DeletePlayer(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            
            try
           { 
                var player =
                    await _context.Players
                    .FirstOrDefaultAsync(c => c.PlayerId == id);

                if(player is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player not found.";
                    return serviceResponse;
                }

                _context.Players.Remove(player);
                await _context.SaveChangesAsync();    

                serviceResponse.Data = 
                    await _context.Players
                    .Select(c => _mapper.Map<GetPlayerDto>(c))
                    .ToListAsync();       
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> GetPlayerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();
            
            try
            {
                var player =
                    await _context.Players
                    .FirstOrDefaultAsync(c => c.PlayerId == id);

                if(player is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Player not found.";
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);  
            }   

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetPlayerDto>>> GetPlayers()
        {
            var serviceResponse = new ServiceResponse<List<GetPlayerDto>>();
            
            var players =
                await _context.Players
                .Select(c => _mapper.Map<GetPlayerDto>(c))
                .ToListAsync();
            
            if(players.Count == 0)
            {
                serviceResponse.Message = "No players found.";
            }

            serviceResponse.Data = players;                
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPlayerDto>> UpdatePlayer(UpdatePlayerDto updatedPlayer)
        {
            var serviceResponse = new ServiceResponse<GetPlayerDto>();            
            try
            {            
                var player = 
                    await _context.Players
                    .FirstOrDefaultAsync(c => c.PlayerId == updatedPlayer.PlayerId);

                if(player is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Character not found.";
                }  

                _mapper.Map(updatedPlayer, player);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetPlayerDto>(player);    
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