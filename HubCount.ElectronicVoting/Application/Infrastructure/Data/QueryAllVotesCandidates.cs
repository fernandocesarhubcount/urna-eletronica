using Application.Endpoints.Candidates;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Application.Infrastructure.Data
{
    /*
     * Usado para criar relatorio, onde mostra a quantidade de votos recebidos. 
     */
    public class QueryAllVotesCandidates
    {
        private readonly IConfiguration configuration;

        public QueryAllVotesCandidates(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<CandidateVoteReportResponse>> Execute()
        {
            const string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=ElectronicVoting;Trusted_Connection=True;MultipleActiveResultSets=True;";
            var db = new SqlConnection(connectionString);
            var query =
                @"select 
                	c.Id,
                	c.Name, 
                	count(*) Amount
                from
                	Votes v inner join VoteCandidates vc on v.Id = vc.VotesId
                	inner join Candidates c on c.Id = vc.CandidatesId
                group by
                	c.Id, c.Name
                order by Amount desc";

            return await db.QueryAsync<CandidateVoteReportResponse>(query);
        }
    }
}
