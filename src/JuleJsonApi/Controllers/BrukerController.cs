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
    public class BrukerController : Controller
    {

        private JuleContext db;

        public BrukerController(JuleContext context)
        {
            db = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Bruker> Get()
        {
            return db.Brukere.ToList();
        }
        [HttpGet("{id}", Name = "GetBruker")]
        public IActionResult GetById(int id)
        {
            var item = db.Brukere.Include(b => b.Rating).ThenInclude(r => r.Drikke).ToList(); ;
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult CreateOrLogin([FromBody] Bruker bruker)
        {
            if (bruker == null)
            {
                return BadRequest();
            }
            var eksisterendeBruker = db.Brukere.FirstOrDefault(b => b.Kode == bruker.Kode);
            if(eksisterendeBruker != null)
            {
                eksisterendeBruker.Navn = bruker.Navn;
                db.SaveChanges();
                return Ok(eksisterendeBruker);
            }

            db.Brukere.Add(bruker);
            db.SaveChanges();
            return CreatedAtRoute("GetBruker", new { id = bruker.BrukerId }, bruker);
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
