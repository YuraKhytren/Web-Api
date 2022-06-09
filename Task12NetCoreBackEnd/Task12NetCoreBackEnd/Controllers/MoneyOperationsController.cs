using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task12NetCoreBackEnd.DataBase;
using Task12NetCoreBackEnd.Models;
using Task12NetCoreBackEnd.Services;
using Task12NetCoreBackEnd.ViewModel;

namespace Task12NetCoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyOperationsController : ControllerBase
    {
        private readonly IService<MoneyOperation> _service;
        private readonly IMapper _mapper;

        public MoneyOperationsController(IService<MoneyOperation> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MoneyOperationViewModel>> GetAllAsync(int type)
        {
            return _mapper.Map<IEnumerable<MoneyOperationViewModel>>(await _service.GetAllAsync(type));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MoneyOperationViewModel>> GetByIdAsync(int id)
        { 
            MoneyOperation model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }     

            return new ObjectResult(_mapper.Map<MoneyOperationViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult<MoneyOperationViewModel>> CreateAsync(MoneyOperationViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<MoneyOperationViewModel>( await _service.CreateAsync(_mapper.Map<MoneyOperation>(model))));
        }

        [HttpPut]
        public async Task<ActionResult<MoneyOperationViewModel>> UpdateAsync(MoneyOperationViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<MoneyOperationViewModel>(await _service.UpdateAsync(_mapper.Map<MoneyOperation>(model))));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {

            if (id == default)
            {
                return NotFound();
            }

            return Ok(await _service.DeleteAsync(id));
        }
    }
}
