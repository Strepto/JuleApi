using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JuleJsonApi.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JuleJsonApi.Controllers
{
    [Route("api/drikke")]
    public class DrikkeController : Controller
    {

        private JuleContext db;
        

        public DrikkeController(JuleContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Drikke> GetAll()
        {
            return db.Drikker.ToList();
        }

        [HttpGet("{id}", Name = "GetDrikke")]
        public IActionResult GetById(int id)
        {
            var item = db.Drikker.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Drikke drikke)
        {
            if (drikke == null)
            {
                return BadRequest();
            }
            

            db.Drikker.Add(drikke);
            db.SaveChanges();
            return CreatedAtRoute("GetDrikke", new { id = drikke.DrikkeId }, drikke);
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
