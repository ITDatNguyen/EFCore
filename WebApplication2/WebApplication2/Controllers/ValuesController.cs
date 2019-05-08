using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domain;

namespace WebApplication2.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DemoContext _db;
        public ValuesController(DemoContext db)
        {
            _db = db;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return _db.Categories.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var cate = _db.Categories.Find(id);

            if (cate == null)
            {
                return NotFound();
            }
            return cate;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Category model)
        {
            var category = new Category();
            category.Name = model.Name;
            category.IsActive = true;
            _db.Add(category);

            _db.SaveChanges();

            return Ok(category);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category model)
        {
            var cate =  _db.Categories.Find(id);
            if (id != model.Id)
            {
                return BadRequest();
            }

            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var cate =  _db.Categories.Find(id);

            if (cate == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(cate);

            _db.SaveChanges();

            return NoContent();
        }
    }
}
