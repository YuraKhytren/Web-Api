using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.DataBase;
using Task12NetCoreBackEnd.Models;

namespace Task12NetCoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyOperationsController : ControllerBase
    {
        AppDbContext _db;
        public MoneyOperationsController(AppDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MoneyOperation>> Get()
        {
            return await _db.MoneyOperations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyOperation>> Get(int id) 
        {
            MoneyOperation model = await _db.MoneyOperations.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
            {
                return NotFound();
            }
            return new ObjectResult(model);
        }

        [HttpPost]
        public async Task<ActionResult<MoneyOperation>> Post(MoneyOperation model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _db.MoneyOperations.Add(model);
            await _db.SaveChangesAsync();
            return Ok(model);

        }

        [HttpPut]
        public async Task<ActionResult<MoneyOperation>> Put(MoneyOperation model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            if (!_db.MoneyOperations.Any(m => m.Id == model.Id))
            {
                return NotFound();
            }

            _db.MoneyOperations.Update(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MoneyOperation>> Delete(int id)
        {
            MoneyOperation model = await _db.MoneyOperations.FirstOrDefaultAsync(m=> m.Id == id);
            if (model == null)
            {
                return NotFound();
            }

            _db.MoneyOperations.Remove(model);
            await _db.SaveChangesAsync();
            return Ok(model);
        }
    } 
}
