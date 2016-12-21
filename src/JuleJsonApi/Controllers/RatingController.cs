using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JuleJsonApi.Model;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JuleJsonApi.Controllers
{
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private JuleContext db;

        public RatingController (JuleContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Rating> Get()
        {
            return db.Ratings.Include(x => x.Bruker).Include(x => x.Drikke).ToList();
        }
        

        [HttpGet("{id}", Name = "GetRating")]
        public IActionResult GetById(int id)
        {
            var item = db.Ratings.Include(r => r.Drikke).Include(r => r.Bruker).FirstOrDefault(r => r.RatingId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Rating rating)
        {
            if (rating == null)
            {
                return BadRequest();
            }
            db.Ratings.Add(rating);
            db.SaveChanges();
            return CreatedAtRoute("GetRating", new { id = rating.RatingId }, rating);
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
