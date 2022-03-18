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
    /// Public Controller for quiz materials, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuizMaterialsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly QuizMaterialMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public QuizMaterialsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.QuizMaterialMapper(mapper);
        }

        // GET: api/QuizMaterials
        /// <summary>
        /// Get all quiz materials
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.QuizMaterial>>> GetQuizMaterials()
        {
            return Ok((await _bll.QuizMaterials.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/QuizMaterials/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.QuizMaterial>> GetQuizMaterial(Guid id)
        {
            var quizMaterial = await _bll.QuizMaterials.FirstOrDefaultAsync(id);

            if (quizMaterial == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(quizMaterial));
        }

        // PUT: api/QuizMaterials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quizMaterial"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizMaterial(Guid id, App.DTO.v1.QuizMaterial quizMaterial)
        {
            if (id != quizMaterial.Id)
            {
                return BadRequest();
            }

            _bll.QuizMaterials.Update(_mapper.Map(quizMaterial));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuizMaterialExists(id))
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

        // POST: api/QuizMaterials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizMaterial"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.QuizMaterial>> PostQuizMaterial(App.DTO.v1.QuizMaterial quizMaterial)
        {
            _bll.QuizMaterials.Add(_mapper.Map(quizMaterial));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetQuizMaterial", new { id = quizMaterial.Id }, quizMaterial);
        }

        // DELETE: api/QuizMaterials/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizMaterial(Guid id)
        {
            var quizMaterial = await _bll.QuizMaterials.FirstOrDefaultAsync(id);
            if (quizMaterial == null)
            {
                return NotFound();
            }

            await _bll.QuizMaterials.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> QuizMaterialExists(Guid id)
        {
            return _bll.QuizMaterials.ExistsAsync(id);
        }
    }
}
