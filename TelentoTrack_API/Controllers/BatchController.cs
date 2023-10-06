using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentoTrack.Common.Entities;
using TalentoTrack.Dao.DB;

namespace TelentoTrack.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BatchController : Controller
    {
        private readonly TalentoTrack_DbContext dbContext;

        public BatchController(TalentoTrack_DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Name = "Batch")]
        public async Task<ActionResult<List<Batch>>> GetBatch()
        {

            var Batchdata = await dbContext.tbl_Batch_details.ToListAsync();

            return Ok(Batchdata);
        }

        [HttpPost(Name = "AddBatch")]
        public async Task<ActionResult<Batch>> AddBatch(Batch newBatch)
        {

            await dbContext.tbl_Batch_details.AddAsync(newBatch);
            await dbContext.SaveChangesAsync();
            return Ok(newBatch);
        }

        [HttpPut(Name = "UpdateBatch/{id}")]
        public async Task<ActionResult<Batch>> UpdateBatch(int id, Batch upIdBatch)
        {
            if (id != upIdBatch.Id)
            {
                return BadRequest();
            }
            dbContext.Entry(upIdBatch).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return Ok(upIdBatch);
        }
        [HttpDelete(Name = "DeleteBatch/{id}")]
        public async Task<ActionResult<Batch>> DeleteBatch(int id)
        {
            var dBatch = await dbContext.tbl_Batch_details.FindAsync(id);
            if (dBatch == null)
            {
                return NotFound();
            }
            dbContext.tbl_Batch_details.Remove(dBatch);
            await dbContext.SaveChangesAsync();
            return Ok();


        }
    }
}