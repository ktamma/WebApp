#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.DAL;
using App.Domain;
using App.Public.Mappers;
using AutoMapper;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Public Controller for takes, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TakesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly TakeMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public TakesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.TakeMapper(mapper);
        }

        // GET: api/Takes
        /// <summary>
        /// Get all takes
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Take>>> GetTakes()
        {
            return Ok((await _bll.Takes.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/Takes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Take>> GetTake(Guid id)
        {
            var take = await _bll.Takes.FirstOrDefaultAsync(id);

            if (take == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(take));
        }

        // PUT: api/Takes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTake(Guid id, App.DTO.v1.Take take)
        {
            if (id != take.Id)
            {
                return BadRequest();
            }

            _bll.Takes.Update(_mapper.Map(take));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TakeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Takes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Take>> PostTake(App.DTO.v1.Take take)
        {
            _bll.Takes.Add(_mapper.Map(take));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTake", new { id = take.Id, Version = HttpContext.GetRequestedApiVersion()?.ToString() }, take);
        }

        // DELETE: api/Takes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTake(Guid id)
        {
            var take = await _bll.Takes.FirstOrDefaultAsync(id);
            if (take == null)
            {
                return NotFound();
            }

            await _bll.Takes.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> TakeExists(Guid id)
        {
            return _bll.Takes.ExistsAsync(id);
        }
    }
}
