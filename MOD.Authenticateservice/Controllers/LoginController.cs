using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOD.Authenticateservice.Models;
using MOD.Authenticateservice.Repository;

namespace MOD.Authenticateservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginRepository _repository;

        
        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }
        // GET: api/Login
        [HttpGet]
        [Route("Validate/{id}/{password}")]
        public Token Get(string id, string password)
        {
            user obj = _repository.UserLogin(id, password);
            Mentor obj1 = _repository.MentorLogin(id, password);

            if (obj != null)
            {
                return new Token() { message = "User", token = GetToken(), };
            }
            else if (obj1 != null)
            {
                return new Token() { message = "Mentor", token = GetToken(), };

            }
            else if (id == "Admin" && password == "Admin")
            {
                return new Token() { message = "Admin", token = GetToken() };

            }
            else
            {
                return new Token() { message = "Invalid User", token = "" };

            }
        }
        public string GetToken()
        {
            return "";
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Login/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Login
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Login/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
