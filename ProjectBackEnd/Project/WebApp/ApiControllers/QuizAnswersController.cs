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
    /// Public Controller for quiz answers, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuizAnswersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly QuizAnswerMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public QuizAnswersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.QuizAnswerMapper(mapper);
        }

        // GET: api/QuizAnswers
        /// <summary>
        /// Get all quiz answers
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.QuizAnswer>>> GetQuizAnswers()
        {
            return Ok((await _bll.QuizAnswers.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/QuizAnswers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.QuizAnswer>> GetQuizAnswer(Guid id)
        {
            var quizAnswer = await _bll.QuizAnswers.FirstOrDefaultAsync(id);

            if (quizAnswer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(quizAnswer));
        }

        // PUT: api/QuizAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quizAnswer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizAnswer(Guid id, App.DTO.v1.QuizAnswer quizAnswer)
        {
            if (id != quizAnswer.Id)
            {
                return BadRequest();
            }

            _bll.QuizAnswers.Update(_mapper.Map(quizAnswer));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await QuizAnswerExists(id))
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

        // POST: api/QuizAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizAnswer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.QuizAnswer>> PostQuizAnswer(App.DTO.v1.QuizAnswer quizAnswer)
        {
            _bll.QuizAnswers.Add(_mapper.Map(quizAnswer));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetQuizAnswer", new { id = quizAnswer.Id }, quizAnswer);
        }

        // DELETE: api/QuizAnswers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizAnswer(Guid id)
        {
            var quizAnswer = await _bll.QuizAnswers.FirstOrDefaultAsync(id);
            if (quizAnswer == null)
            {
                return NotFound();
            }

            await _bll.QuizAnswers.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> QuizAnswerExists(Guid id)
        {
            return _bll.QuizAnswers.ExistsAsync(id);
        }
    }
}
