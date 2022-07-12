using BookStore1.Models.Model;
using BookStore1.Models.Models;
using BookStore1.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookStore1.Api.Controllers
{
    [Route("api/public")]
    [ApiController]
    public class BookStoreController : ControllerBase
    {
        UserRepository _repository = new UserRepository();

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {
            try
            {
                User user = _repository.Login(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User not found");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                User user = _repository.Register(model);
                if (user == null)
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "Bad request");

                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
            }
        }
    }
}
