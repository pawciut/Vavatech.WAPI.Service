using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Vavatech.WAPI.MockServices;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Service.ActionFilters;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.Service.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService userService;

        public UsersController()
            : this(new MockUsersService())
        {
        }

        public UsersController(IUsersService usersService)
        {
            this.userService = usersService;
        }

        //public IHttpActionResult Get()
        //{
        //    return Ok(userService.Get());
        //}

        [Route("{id:int}")]
        [HttpGet]
        [ExecutionTimeActionFilter]
        public IHttpActionResult Get(int id)
        {
            var user = userService.Get(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        
        [Route(@"{pesel:regex(^\d{11}$)}")]
        [HttpGet]
        public IHttpActionResult GetByPesel(string pesel)
        {
            var user = userService.GetByPesel(pesel);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // api/users?firstname=Marcin&lastname=Sulecki
        [HttpGet]
        public IHttpActionResult Get([FromUri] UserSearchCriteria criteria)
        {
            var user = userService.Get(criteria);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        public IHttpActionResult Post(User user)
        {
            userService.Add(user);
            //return Created($"http://localhost:50302/api/users/{user.Id}", user);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
            //on error BadRequest();
        }

        [Route("{id}")]
        public IHttpActionResult Put(int id, User user)
        {
            if (id != user.Id)
                return BadRequest();

            userService.Update(user);
            return Ok();
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var user = userService.Get(id);

            if (user == null)
                return NotFound();

            userService.Remove(id);
            return Ok();
        }
    }
}