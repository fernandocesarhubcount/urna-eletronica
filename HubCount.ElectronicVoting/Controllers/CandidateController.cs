using HubCount.ElectronicVoting.Data;
using HubCount.ElectronicVoting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HubCount.ElectronicVoting.Controllers
{
    public class CandidateController : Controller
    {
        private readonly DataContext _context;

        public CandidateController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidates.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Candidate());
            else
            {
                return View(_context.Candidates.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("CandidateId,Name,ViceName,Election,Status,Legend")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                if (candidate.CandidateId == 0)
                    _context.Add(candidate);
                else
                    _context.Update(candidate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidates == null)
            {
                return Problem("Entity set 'DataContext.Candidates'  is null.");
            }
            var candidate = await _context.Candidates.FindAsync(id);
            if (candidate != null)
            {
                _context.Candidates.Remove(candidate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
