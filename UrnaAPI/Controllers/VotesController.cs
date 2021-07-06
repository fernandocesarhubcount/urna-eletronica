using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrnaAPI.Data;
using UrnaAPI.Models;

namespace UrnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly UrnaAPIContext _context;

        public VotesController(UrnaAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vote>>> GetVote()
        {
            var votes = await _context.Vote.ToListAsync();

            foreach (var vote in votes)
            {
                vote.Candidate = _context.Candidate.FirstOrDefault(v => v.CandidateId == vote.CandidateId);
            }

            return votes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vote>> GetVote(int id)
        {
            var vote = await _context.Vote.FindAsync(id);

            if (vote == null)
            {
                return NotFound();
            }

            return vote;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVote(int id, Vote vote)
        {
            if (id != vote.VoteId)
            {
                return BadRequest();
            }

            _context.Entry(vote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Vote>> PostVote(Vote voteViewModel)
        {
            try
            {
                Candidate candidate = _context.Candidate.Single(c => c.CandidateId == voteViewModel.CandidateId);
                Vote newVote = new Vote
                {
                    CandidateId = voteViewModel.CandidateId,
                    VoteId = voteViewModel.VoteId,
                    Candidate = candidate,
                    RegistryDate = voteViewModel.RegistryDate
                };

                _context.Vote.Add(newVote);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetVote", new { id = newVote.VoteId }, newVote);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVote(int id)
        {
            var vote = await _context.Vote.FindAsync(id);
            if (vote == null)
            {
                return NotFound();
            }

            _context.Vote.Remove(vote);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VoteExists(int id)
        {
            return _context.Vote.Any(e => e.VoteId == id);
        }
    }
}
