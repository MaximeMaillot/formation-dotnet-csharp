using AutoMapper;
using EFHelper.Interfaces;
using EFHelper.Repositories;
using GenericClassHelper.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace ApiHelper.Controllers
{
    [ApiController]
    public class GenericController<TEntity, TEntityDTO> : ControllerBase where TEntity : class 
                                                                         where TEntityDTO : class
    {
        protected readonly IRepository<TEntity> _genericRepository;
        protected readonly IMapper _mapper;

        public GenericController(IRepository<TEntity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            List<TEntity> entities = await _genericRepository.GetAllAsync();
            var entitiesDTO = _mapper.Map<List<TEntity>, List<TEntityDTO>>(entities);
            return Ok(new
            {
                Message = "",
                Data = entitiesDTO
            });
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            TEntity entity = await _genericRepository.FindAsync(id);
            var entityDTO = _mapper.Map<TEntity, TEntityDTO>(entity);
            return Ok(new
            {
                Message = "",
                Data = entityDTO
            });
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityDTO entityDTO)
        {
            var entity = _mapper.Map<TEntityDTO, TEntity>(entityDTO);
            int id = await _genericRepository.AddAsync(entity);
            GenericClass<TEntityDTO>.SetValue(entityDTO, "Id", id);
            return Ok(new
            {
                Message = "",
                Id = id,
                Data = entityDTO
            });
        }

        [HttpPut]
        public virtual async Task<IActionResult> Put([FromBody] TEntityDTO entityDTO)
        {
            var entity = _mapper.Map<TEntityDTO, TEntity>(entityDTO);
            if (await _genericRepository.UpdateAsync(entity))
            {
                return Ok(new
                {
                    Message = "",
                    Data = entityDTO
                });
            }
            return BadRequest(new {
                Message = "Error"
            });
        }

        
        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] object id, [FromBody] TEntityDTO entityDTO)
        {
            if (id != GenericClass<TEntityDTO>.GetValue(entityDTO, "Id"))
            {
                GenericClass<TEntityDTO>.SetValue(entityDTO, "Id", id);
                await Put(entityDTO);
            }
            return NotFound(new
            {
                Message = "Not Found"
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual IActionResult Remove([FromRoute] int id)
        {
            if (_genericRepository.Remove(id))
            {
                return Ok(new
                {
                    Message = "",
                    Removed = id
                });
            }
            return BadRequest(new
            {
                Message = "Error"
            });
        }
    }
}
