using CarAccidentAPI.Context;
using CarAccidentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarAccidentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> GetAllCities()
        {
            return _context.Cities;
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public ActionResult<City> GetCityById(int id)
        {
            var model = _context.Cities.Find(id);

            if (model == null)
            {
                return NotFound();
            }
            else
            {
                return model;
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public void CreateCity([FromBody] City model)
        {
            if (model is not null)
            {
                _context.Cities.Add(model);
                _context.SaveChanges();
            }
        }

        // PUT api/<CityController>/cairo
        [HttpPost("{cityName}")]
        public void UpdateAccidentsCount(string cityName)
        {
            var city = _context.Cities.FromSqlRaw("SELECT * FROM dbo.Cities").Where(b => b.Name.ToLower() == cityName.ToLower()).ToList().FirstOrDefault();
            city.AccidentsCount += 1;

            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public void UpdateCity(int id, [FromBody] City model)
        {
            var city = _context.Cities.Find(id);

            city.Name = model.Name;
            city.AccidentsCount = model.AccidentsCount;

            _context.Cities.Update(city);
            _context.SaveChanges();
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = _context.Cities.Find(id);
            if (model is not null)
            {
                _context.Cities.Remove(model);
                _context.SaveChanges();
            }
        }
    }
}
