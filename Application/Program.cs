using Application.Endpoints.Elections;
using Application.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Application.Endpoints.Candidates;
using Application.Endpoints.Electorates;
using Application.Endpoints.Votes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<QueryAllVotesCandidates>();


// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//endpoints
app.MapMethods(ElectionGetAll.Template, ElectionGetAll.Methods, ElectionGetAll.Handler);
//app.MapMethods(ElectionPut.Template, ElectionPut.Methods, ElectionPut.Handler);
app.MapMethods(ElectionPost.Template, ElectionPost.Methods, ElectionPost.Handler);


app.MapMethods(CandidatePost.Template, CandidatePost.Methods, CandidatePost.Handler);
app.MapMethods(CandidateGetAll.Template, CandidateGetAll.Methods, CandidateGetAll.Handler);
app.MapMethods(CandidateDelete.Template, CandidateDelete.Methods, CandidateDelete.Handler);
//Retornar total de votos
app.MapMethods(CandidateVoteGet.Template, CandidateVoteGet.Methods, CandidateVoteGet.Handler);


app.MapMethods(ElectorateGet.Template, ElectorateGet.Methods, ElectorateGet.Handler);


app.MapMethods(VotePost.Template, VotePost.Methods, VotePost.Handler);
app.MapMethods(VoteGet.Template, VoteGet.Methods, VoteGet.Handler);


app.Run();
