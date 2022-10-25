using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Travel.Models;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace Travel.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelContext _db;

    public ReviewsController(TravelContext db)
    {
      _db = db;
    }
    // GET api/review
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string name, string city, string country, int rating)
    {
      var query = _db.Reviews.AsQueryable();

      if(name != null)
      {
        query = query.Where(e => e.Name.ToLower() == name);
      }
      if(city != null)
      {
        query = query.Where(e => e.City.ToLower() == city);
      }
      if(country != null)
      {
        query = query.Where(e => e.Country.ToLower() == country);
      }
      if (rating > 0)
      {
        query = query.Where(e => e.Rating == rating);
      }

      return await query.OrderByDescending(e => e.Rating).ToListAsync();
    }

    // GET api/review/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
        var review = await _db.Reviews.FindAsync(id);

        if (review == null)
        {
            return NotFound();
        }

        return review;
    }

    // POST api/review
    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Reviews.Add(review);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetReview), new { id = review.ReviewId }, review);
    }

    // PUT: api/Reviews/1
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review, string name)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
        // if (!UserExists(name))
        // {
        //   return NotFound();
        // }
        // else
        // {
        //   throw;
        // }
      }
      return NoContent();
    }

    private bool ReviewExists(int id)
    {
      return _db.Reviews.Any(e => e.ReviewId == id);
    }
    private bool UserExists(string name)
    {
      return _db.Reviews.Any(e => e.Name == name);
    }
    // DELETE: api/Reviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Reviews.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Reviews.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}
