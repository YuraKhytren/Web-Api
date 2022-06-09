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
    public class FinanceTypesController : ControllerBase
    {
        private readonly IService<FinanceType> _service;
        private readonly IMapper _mapper;

        public FinanceTypesController(IService<FinanceType> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<FinanceTypeViewModel>> GetAllAsync(int type)
        {

            return _mapper.Map<IEnumerable<FinanceTypeViewModel>>(await _service.GetAllAsync(type));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceTypeViewModel>> GetByIdAsync(int id)
        {
            FinanceType model = await _service.GetByIdAsync(id);

            if (model == null)
            {
                return BadRequest();
            }


            return new ObjectResult(_mapper.Map<FinanceTypeViewModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult<FinanceTypeViewModel>> PostAsync(FinanceTypeViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<FinanceTypeViewModel>(await _service.CreateAsync(_mapper.Map<FinanceType>(model))));
        }

        [HttpPut]
        public async Task<ActionResult<FinanceTypeViewModel>> PutAsync(FinanceTypeViewModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
    
            return Ok(_mapper.Map<FinanceTypeViewModel>(await _service.UpdateAsync(_mapper.Map<FinanceType>( model))));
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
