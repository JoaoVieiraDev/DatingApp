using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
         private readonly DataContext _context;
        public BuggyController(DataContext context){
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        [HttpGet("server-error-try-catch")]
        public ActionResult<string> GetServerErrortryCatch()
        {
            try {
                var thing = _context.Users.Find(-1);
                return thing.ToString();
            }
            catch (Exception ex) {
                return StatusCode(500, "Computer says no!");
            }
            
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            try {
                var thing = _context.Users.Find(-1);
                return thing.ToString();
            }
            catch (Exception ex) {
                return StatusCode(500, "Computer says no!");
            }
            
        }
    }
}