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
    /// Public Controller for categories, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly CategoryMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public CategoriesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.CategoryMapper(mapper);
        }

        // GET: api/Categories
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Category>>> GetCategories()
        {
            return Ok((await _bll.Categories.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/Categories/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Category>> GetCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(category));
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, App.DTO.v1.Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _bll.Categories.Update(_mapper.Map(category));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Category>> PostCategory(App.DTO.v1.Category category)
        {
            _bll.Categories.Add(_mapper.Map(category));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _bll.Categories.FirstOrDefaultAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _bll.Categories.Remove(category);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> CategoryExists(Guid id)
        {
            return _bll.Categories.ExistsAsync(id);
        }
    }
}
