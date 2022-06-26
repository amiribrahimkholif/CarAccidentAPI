using CarAccidentAPI.Context;
using CarAccidentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarAccidentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccidentController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public AccidentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<AccidentController>
        [HttpGet]
        public IEnumerable<Accident> GetAllAccidents()
        {
            return _context.Accidents;
        }

        // GET api/<AccidentController>/5
        [HttpGet("{id}")]
        public ActionResult<Accident> GetAccidentById(int id)
        {
            var model = _context.Accidents.Find(id);

            if(model == null )
            {
                return NotFound();
            }
            else
            {
                return model;
            }
        }

        // POST api/<AccidentController>
        [HttpPost]
        public void CreateAccident([FromBody] Accident model)
        {
            if(model is not null)
            {
                _context.Accidents.Add(model);
                _context.SaveChanges();
            }

        }

        // PUT api/<AccidentController>/5
        [HttpPut("{id}")]
        public void UpdateAccident(int id, [FromBody] Accident model)
        {
            var accident = _context.Accidents.Find(id);

            accident.City = model.City;
            accident.IsAccident = model.IsAccident;
            accident.Time = model.Time;

            _context.Accidents.Update(accident);
            _context.SaveChanges();
        }

        // DELETE api/<AccidentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = _context.Accidents.Find(id);
            if(model is not null)
            {
                _context.Accidents.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
