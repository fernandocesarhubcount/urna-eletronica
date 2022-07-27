using Application.Data.Converters;
using Application.Data.Converters.Interfaces;
using Application.Data.DataTransferObjects.Candidates;
using Application.Data.DataTransferObjects.Votes;
using Application.DataTransferObjects.Votes;
using Application.UseCases.Implementations;
using Application.UseCases.Implementations.Votes;
using Application.UseCases.Interfaces;
using Application.UseCases.Interfaces.Votes;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Model.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("database");
builder.Services.AddDbContext<DataContext>(dbc => dbc.UseSqlite(connectionString));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
#region Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
                      builder =>
                      {
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                      });
});
#endregion
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region UseCases Dependence Inversion
builder.Services.AddTransient<ICreateOneCandidateUseCase, CreateOneCandidateUseCase>();
builder.Services.AddTransient<IDeleteOneCandidateUseCase, DeleteOneCandidateUseCase>();
builder.Services.AddTransient<IGetAllCandidatesUseCase, GetAllCandidatesUseCase>();
builder.Services.AddTransient<IGetOneCandidateUseCase, GetOneCandidateUseCase>();
builder.Services.AddTransient<ICreateOneVoteUseCase, CreateOneVoteUseCase>();
builder.Services.AddTransient<IGetAllVotesUseCase, GetAllVotesUseCase>();
#endregion

#region Repositories Dependence Inversion
builder.Services.AddTransient<ICandidatesRepository, CandidatesRepository>();
builder.Services.AddTransient<IVotesRepository, VotesRepository>();
#endregion

#region Converters Dependence Inversion
builder.Services.AddTransient<IConverter<Candidate, CandidateRequestDto, CandidateResponseDto>, CandidateConverter>();
builder.Services.AddTransient<IConverter<Vote, VoteRequestDto, CandidatesVoteResponseDto>, VoteConverter>();
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("MyPolicy");
app.Run();
