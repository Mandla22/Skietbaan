using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend_Skietbaan_T2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Skietbaan_T2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private ModelsContext _context;
        public UserController(ModelsContext db)
        {
            _context = db;
        }


        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _context.Users.ToArray<User>();
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            User user = _context.Users.Find(id);
            return user;
        }

        // POST: api/User
        [HttpPost]
        public string Post([FromBody] User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            string ret = "Posted: " + user.Username;
            return ret;
        }

        // PUT: api/User/5
        [HttpPut]
        public void Put([FromBody] User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
