using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.Service.Controllers
{
	//[RoutePrefix("api/stations")]
    public class StationsController : ApiController
    {
        private readonly IStationsService stationService;

        public StationsController()
            : this(new MockStationsService())
        {
        }

        public StationsController(IStationsService stationsService)
        {
            this.stationService = stationsService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(stationService.Get());
        }

        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            var station = stationService.Get(id);
            if (station == null)
                return NotFound();
            return Ok(station);
        }

        [Route("{name}")]
        [HttpGet]
        public IHttpActionResult Get(string name)
        {
            var station = stationService.Get(name);
            if (station == null)
                return NotFound();
            return Ok(station);
        }
        
        //api/stations?lat={latitude}&lng={longitude}
        [HttpGet]
        public IHttpActionResult GetByLocation(float lat, float lng)
        {
            //var station = stationService.GetByLocation(name);
            //if (station == null)
            //    return NotFound();
            //return Ok(station);
            return Ok();
        }

        public IHttpActionResult Post(Station station)
        {
            stationService.Add(station);
            //return Created($"http://localhost:50302/api/stations/{station.Id}", station);
            return CreatedAtRoute("DefaultApi", new { id = station.Id }, station);
            //on error BadRequest();
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, Station station)
        {
            if (id != station.Id)
                return BadRequest();

            stationService.Update(station);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var station = stationService.Get(id);

            if (station == null)
                return NotFound();

            stationService.Remove(id);
            return Ok();
        }
    }
}