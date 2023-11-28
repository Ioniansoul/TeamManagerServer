global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Mvc;

global using TeamManagerServer.Data;
global using TeamManagerServer.Models;

global using TeamManagerServer.Dtos.Player;
global using TeamManagerServer.Dtos.Game;
global using TeamManagerServer.Dtos.Team;
global using TeamManagerServer.Dtos.Transaction;

global using TeamManagerServer.Services.TeamService;
global using TeamManagerServer.Services.GameService;
global using TeamManagerServer.Services.PlayerService;
global using TeamManagerServer.Services.TransactionService;




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
