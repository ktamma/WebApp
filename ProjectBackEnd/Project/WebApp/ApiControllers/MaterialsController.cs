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
    /// Public Controller for materials, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly MaterialMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public MaterialsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.MaterialMapper(mapper);
        }

        // GET: api/Materials
        /// <summary>
        /// Get all materials
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Material>>> GetMaterials()
        {
            return Ok((await _bll.Materials.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/Materials/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Material>> GetMaterial(Guid id)
        {
            var material = await _bll.Materials.FirstOrDefaultAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(material));
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(Guid id, App.DTO.v1.Material material)
        {
            if (id != material.Id)
            {
                return BadRequest();
            }

            _bll.Materials.Update(_mapper.Map(material));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MaterialExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="material"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Material>> PostMaterial(App.DTO.v1.Material material)
        {
            _bll.Materials.Add(_mapper.Map(material));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetMaterial", new { id = material.Id }, material);
        }

        // DELETE: api/Materials/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterial(Guid id)
        {
            var material = await _bll.Materials.FirstOrDefaultAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            await _bll.Materials.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> MaterialExists(Guid id)
        {
            return _bll.Materials.ExistsAsync(id);
        }
    }
}
