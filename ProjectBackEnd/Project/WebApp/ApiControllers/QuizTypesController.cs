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
using App.DAL.Contracts;
using App.Domain;
using App.Public.Mappers;
using AutoMapper;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Public Controller for quiz types, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuizTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly QuizTypeMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public QuizTypesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.QuizTypeMapper(mapper);
        }

        // GET: api/QuizTypes
        /// <summary>
        /// Get all quiz types
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.QuizType>>> GetQuizTypes()
        {
            return Ok((await _bll.QuizTypes.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/QuizTypes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.QuizType>> GetQuizType(Guid id)
        {
            var quizType = await _bll.QuizTypes.FirstOrDefaultAsync(id);

            if (quizType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(quizType));
        }

        // PUT: api/QuizTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quizType"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizType(Guid id, App.DTO.v1.QuizType quizType)
        {
            if (id != quizType.Id)
            {
                return BadRequest();
            }

            _bll.QuizTypes.Update(_mapper.Map(quizType));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuizTypeExists(id))
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

        // POST: api/QuizTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizType"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.QuizType>> PostQuizType(App.DTO.v1.QuizType quizType)
        {
            _bll.QuizTypes.Add(_mapper.Map(quizType));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetQuizType", new { id = quizType.Id }, quizType);
        }

        // DELETE: api/QuizTypes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizType(Guid id)
        {
            var quizType = await _bll.QuizTypes.FirstOrDefaultAsync(id);
            if (quizType == null)
            {
                return NotFound();
            }

            await _bll.QuizTypes.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> QuizTypeExists(Guid id)
        {
            return _bll.QuizTypes.ExistsAsync(id);
        }
    }
}
