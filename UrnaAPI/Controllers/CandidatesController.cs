using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrnaAPI.Models;
using UrnaAPI.Data;

namespace UrnaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly UrnaAPIContext _context;

        public CandidatesController(UrnaAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetCandidate()
        {
            var candidates = await _context.Candidate.ToListAsync();

            foreach (var candidate in candidates)
            {
                candidate.Votes = _context.Vote.Where(v => v.CandidateId == candidate.CandidateId).ToList();
            }

            return candidates;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidate>> GetCandidate(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return candidate;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidate(int id, Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return BadRequest();
            }

            _context.Entry(candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(id))
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
        public async Task<ActionResult<Candidate>> PostCandidate(Candidate candidate)
        {
            if (candidate == null) return BadRequest();
            if (String.IsNullOrEmpty(candidate.CandidateName))              return BadRequest();
            if (String.IsNullOrEmpty(candidate.ViceName))                   return BadRequest();
            if (String.IsNullOrEmpty(candidate.Ticket.ToString()))          return BadRequest();
            if (String.IsNullOrEmpty(candidate.RegistryDate.ToString()))    return BadRequest();

            try
            {
                _context.Candidate.Add(candidate);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCandidate", new { id = candidate.CandidateId }, candidate);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var candidate = await _context.Candidate.FindAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            _context.Vote.ToList().RemoveAll(p => p.CandidateId == id);

            _context.Candidate.Remove(candidate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.CandidateId == id);
        }
    }
}