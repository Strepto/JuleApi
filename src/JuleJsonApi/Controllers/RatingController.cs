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
            return db.Ratings.Include(x => x.Bruker).Include(x => x.Drikke).OrderByDescending(x => x.DateModified).ToList();
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

        [HttpGet("user", Name = "GetRatingForUser")]
        public IActionResult GetByUserId([FromQuery]int userid, [FromQuery] int drikkeid)
        {
            var item = db.Ratings.Include(r => r.Drikke).Include(r => r.Bruker).Where(r => r.DrikkeID == drikkeid).FirstOrDefault(r => r.BrukerID == userid);
            if (item == null)
            {
                return BadRequest();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult CreateOrUpdate([FromBody] Rating rating)
        {
            if (rating == null)
            {
                return BadRequest();
            }
            var eksisterendeRating = db.Ratings.Where(r => r.DrikkeID == rating.DrikkeID).Where(r => r.BrukerID == rating.BrukerID).FirstOrDefault();
            if (eksisterendeRating != null)
            {
                eksisterendeRating.Karakter = rating.Karakter;
                eksisterendeRating.SmakerJul = rating.SmakerJul;
                eksisterendeRating.Nokkelord = rating.Nokkelord;
                eksisterendeRating.Bilde = rating.Bilde;
                db.SaveChanges();
                return Ok(eksisterendeRating);
            }
            db.Ratings.Add(rating);
            db.SaveChanges();
            return CreatedAtRoute("GetRating", new { id = rating.RatingId }, rating);
        }
        

        [HttpGet]
        [Route("sortedrated")]
        public IEnumerable<RatingTopListVM> GetTopList()
        {
            var allRatings = db.Ratings.Include(r => r.Drikke).Include(r => r.Bruker).ToList();
            var topList = from rating in allRatings
                       group rating by rating.DrikkeID into rGroup 
                       select new RatingTopListVM { AverageRating = (int)rGroup.Average(r => r.Karakter), RatingId = rGroup.First().RatingId,   Ratings = rGroup.Select(r => r.Karakter).ToList(), Bilder = rGroup.Select(r => r.Bilde).ToList(), Nokkelord = rGroup.Select(r => r.Bilde).ToList(), SmakerJulArray = rGroup.Select(r => r.SmakerJul).ToList() };

            var topListFinished = new List<RatingTopListVM>();
            foreach (var item in topList)
            {
                var rating = allRatings.FirstOrDefault(r => r.RatingId == item.RatingId);
                if (rating != null)
                {
                    
                    item.Navn = rating.Drikke.Navn;
                    item.Bryggeri = rating.Drikke.Bryggeri;
                    topListFinished.Add(item);
                }
            }

            var topListList = topListFinished.OrderByDescending(r => r.AverageRating).ToList();
            return topListList;
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
