using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Entities;
using TalentoTrack.Dao.DB;

namespace TelentoTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly TalentoTrack_DbContext dbContext;

        public UserController(TalentoTrack_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "User")]
        public async Task<ActionResult<List<User>>> GetUser() {

            var userdata = await dbContext.tbl_user.ToListAsync();

            return Ok(userdata);
        }

        [HttpPost(Name = "AddUser")]
        public async Task<ActionResult<User>> AddUser(User newuser)
        {

            await dbContext.tbl_user.AddAsync(newuser);
            await dbContext.SaveChangesAsync();
            return Ok(newuser);
        }

        [HttpPut(Name = "UpdateUser/{id}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User upIdUser)
        {
            if(id!= upIdUser.Id)
            {
                return BadRequest();
            }
            dbContext.Entry(upIdUser).State= EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(upIdUser);
        }
        [HttpDelete(Name = "DeleteUser/{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var duser = await dbContext.tbl_user.FindAsync(id);
            if(duser == null)
            {
                return NotFound();
            }
             dbContext.tbl_user.Remove(duser);
            await dbContext.SaveChangesAsync();
            return Ok();


        }
    }
}
