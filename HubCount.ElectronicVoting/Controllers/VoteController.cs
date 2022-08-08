using HubCount.ElectronicVoting.Data;
using HubCount.ElectronicVoting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HubCount.ElectronicVoting.Controllers
{
    public class VoteController : Controller
    {
        private readonly DataContext _context;

        public VoteController(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Votes.Include(v => v.Candidates);
            return View(await dataContext.ToListAsync());
        }


        public IActionResult AddVote(int id = 0)
        {
            PopulateCandidates();
            if (id == 0)
                return View(new Vote());
            else
                return View(_context.Votes.Find(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVote([Bind("VoteId,CandidateId,Amount,Date")] Vote vote)
        {
            if (ModelState.IsValid)
            {
                vote.Amount += 1;
                _context.Add(vote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            PopulateCandidates();
            return View(vote);
        }

        [NonAction]
        public void PopulateCandidates()
        {
            var CandidateCollection = _context.Candidates.ToList();
            Candidate DefaultCandidate = new Candidate() { CandidateId = 0, Name = "Selecione o candidato" };
            CandidateCollection.Insert(0, DefaultCandidate);
            ViewBag.Candidates = CandidateCollection;
        }
    }
}
