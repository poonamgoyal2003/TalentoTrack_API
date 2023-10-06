using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Entities;
using TalentoTrack.Dao.DB;

namespace TelentoTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CourseController : Controller
    {
        private readonly TalentoTrack_DbContext dbContext;

        public CourseController(TalentoTrack_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "Course")]
        public async Task<ActionResult<List<Course>>> GetCourse()
        {

            var Coursedata = await dbContext.tbl_Course_details.ToListAsync();

            return Ok(Coursedata);
        }

        [HttpPost(Name = "AddCourse")]
        public async Task<ActionResult<Course>> AddCourse(Course newcourse)
        {

            await dbContext.tbl_Course_details.AddAsync(newcourse);
            await dbContext.SaveChangesAsync();
            return Ok(newcourse);
        }

        [HttpPut(Name = "UpdateCourse/{id}")]
        public async Task<ActionResult<Course>> UpdateCourse(int id, Course upIdCourse)
        {
            if (id != upIdCourse.Id)
            {
                return BadRequest();
            }
            dbContext.Entry(upIdCourse).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(upIdCourse);
        }
        [HttpDelete(Name = "DeleteCourse/{id}")]
        public async Task<ActionResult<Course>> DeleteCourse(int id)
        {
            var dcourse = await dbContext.tbl_Course_details.FindAsync(id);
            if (dcourse == null)
            {
                return NotFound();
            }
            dbContext.tbl_Course_details.Remove(dcourse);
            await dbContext.SaveChangesAsync();
            return Ok();


        }
    }
}