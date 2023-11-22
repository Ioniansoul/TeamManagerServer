namespace TeamManagerServer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddPlayerDto, Player>(); 
            CreateMap<Player, GetPlayerDto>();
            CreateMap<UpdatePlayerDto, Player>();
            CreateMap<AddTeamDto, Team>(); 
            CreateMap<Team, GetTeamDto>();
            CreateMap<UpdateTeamDto, Team>();
            CreateMap<AddGameDto, Game>();
            CreateMap<Game, GetGameDto>();
            CreateMap<UpdateGameDto, Game>();
            CreateMap<AddTransactionDto, Transaction>();
            CreateMap<Transaction, GetTransactionDto>();
            CreateMap<UpdateTransactionDto, Transaction>();
        }
    }
}
