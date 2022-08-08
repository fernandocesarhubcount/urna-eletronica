using HubCount.ElectronicVoting.Data;
using HubCount.ElectronicVoting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HubCount.ElectronicVoting.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DataContext _context;

        public DashboardController(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {

            List<Vote> SelectedVotes = await _context.Votes
                .Include(x => x.Candidates)
                .ToListAsync();

            int TotalStatus = SelectedVotes
                .Where(i => i.Candidates.Status == "Active")
                .Sum(j => j.Amount);
            ViewBag.TotalStatus = TotalStatus.ToString();


            ViewBag.DoughnutChartData = SelectedVotes
                .Where(i => i.Candidates.Status == "Active")
                .GroupBy(j => j.Candidates.CandidateId)
                .Select(k => new
                {
                    candidateTitle = k.First().Candidates.Name,
                    amount = k.Sum(j => j.Amount),
                    formattedAmount = k.Sum(j => j.Amount).ToString(),
                })
                .OrderByDescending(l => l.amount)
                .ToList();

            ViewBag.RecentVotes = await _context.Votes
                .Include(i => i.Candidates)
                .OrderByDescending(j => j.Date)
                .Take(10)
                .ToListAsync();
            return View();
        }
    }
}
