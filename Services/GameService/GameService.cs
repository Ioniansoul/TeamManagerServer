namespace TeamManagerServer.Services.GameService
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GameService (DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetGameDto>>> AddGame(AddGameDto newGame)
        {
            var serviceResponse = new ServiceResponse<List<GetGameDto>>();
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var game = _mapper.Map<Game>(newGame);
                    _context.Games.Add(game);
                    await _context.SaveChangesAsync();
                    dbTransaction.Commit();
                }

                catch (Exception)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Team not found.";
                    dbTransaction.Rollback();
                }
            }

            serviceResponse.Data = 
                await _context.Games
                .Select(c => _mapper.Map<GetGameDto>(c))
                .ToListAsync();

            return serviceResponse;   
        }

        public async Task<ServiceResponse<List<GetGameDto>>> DeleteGame(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetGameDto>>();
            
            try
            { 
                var game =
                    await _context.Games
                    .FirstOrDefaultAsync(c => c.GameId == id);

                if(game is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Game not found.";
                    return serviceResponse;
                }

                _context.Games.Remove(game);
                await _context.SaveChangesAsync();    

                serviceResponse.Data = 
                    await _context.Games
                    .Select(c => _mapper.Map<GetGameDto>(c))
                    .ToListAsync();       
            }

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGameDto>> GetGameById(int id)
        {
            var serviceResponse = new ServiceResponse<GetGameDto>();
            
            try
            {
                var game =
                    await _context.Games
                    .FirstOrDefaultAsync(c => c.GameId == id);

                if(game is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Game not found.";
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<GetGameDto>(game);  
            }   

            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetGameDto>>> GetGames()
        {
            var serviceResponse = new ServiceResponse<List<GetGameDto>>();
            
            var games =
                await _context.Games
                .Select(c => _mapper.Map<GetGameDto>(c))
                .ToListAsync();            
            if(games.Count == 0)
            {
                serviceResponse.Message = "No games found.";
                return serviceResponse;
            }

            serviceResponse.Data = games;                
                
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetGameDto>> UpdateGame(UpdateGameDto updatedGame)
        {
            var serviceResponse = new ServiceResponse<GetGameDto>();     
            using (var dbTransaction = _context.Database.BeginTransaction())
            {
                try
                {            
                    var game = 
                        await _context.Games
                        .FirstAsync(c => c.GameId == updatedGame.GameId);                  
                 
                    _mapper.Map(updatedGame, game);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _mapper.Map<GetGameDto>(game);
                    dbTransaction.Commit();
                }    

                catch (Exception)
                {   
                    serviceResponse.Success = false;
                    serviceResponse.Message = "An unknown error occurred.";
                    dbTransaction.Rollback();
                    return serviceResponse;
                }          
    
            return serviceResponse;
            }
        }
    }
}