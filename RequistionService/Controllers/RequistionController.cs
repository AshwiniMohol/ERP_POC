using RequistionService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using RequistionService.Data;

namespace RequistionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class RequisitionController : ControllerBase
 {
    private readonly AppDbContext _context;

    public RequisitionController(AppDbContext context){
        _context = context;
    }

// GET: api/Requisition
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Requisition>>> GetRequisition()
  {
    return await _context.Requisitionsions.ToListAsync(); 
  }

// GET: api/Requisition/5
[HttpGet]
public async Task<ActionResult<Requisition>> GetRequistion(int id){

    var requistion = await _context.Requisitionsions.FindAsync(id);
    if(requistion == null)
    {

        return NotFound();
    }

    return requisition;
}

// // POST: api/Requisition/
// [HttpPost]
// public async Task<ActionResult<Requisition>> CreateRequistion(Requisition requistion){

//_context.Requisitions.Add(requisition); // ✅ use Requisitions
//    await _context.SaveChangesAsync();

   // return CreatedAtAction(nameof(GetById), new { id = requisition.Id }, requisition);
//     return createAction(nameof(GetRequistion), new { id =  request.id}, ;});
// }

        // // PUT: api/Requisition/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutRequisition(int id, Requisition requisition)
        // {
        //     if (id != requisition.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(requisition).State = EntityState.Modified;
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        // // DELETE: api/Requisition/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteRequisition(int id)
        // {
        //     var requisition = await _context.Requisitions.FindAsync(id);
        //     if (requisition == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Requisitions.Remove(requisition);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

 }
}