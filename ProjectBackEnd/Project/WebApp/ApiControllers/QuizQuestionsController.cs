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
    /// Public Controller for quiz questions, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuizQuestionsController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly QuizQuestionMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public QuizQuestionsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.QuizQuestionMapper(mapper);
        }

        // GET: api/QuizQuestions
        /// <summary>
        /// Get all quiz questions
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.QuizQuestion>>> GetQuizQuestions()
        {
            return Ok((await _bll.QuizQuestions.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/QuizQuestions/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.QuizQuestion>> GetQuizQuestion(Guid id)
        {
            var quizQuestion = await _bll.QuizQuestions.FirstOrDefaultAsync(id);

            if (quizQuestion == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(quizQuestion));
        }

        // PUT: api/QuizQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quizQuestion"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuizQuestion(Guid id, App.DTO.v1.QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.Id)
            {
                return BadRequest();
            }

            _bll.QuizQuestions.Update(_mapper.Map(quizQuestion));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await QuizQuestionExists(id))
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

        // POST: api/QuizQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quizQuestion"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.QuizQuestion>> PostQuizQuestion(App.DTO.v1.QuizQuestion quizQuestion)
        {
            _bll.QuizQuestions.Add(_mapper.Map(quizQuestion));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetQuizQuestion", new { id = quizQuestion.Id }, quizQuestion);
        }

        // DELETE: api/QuizQuestions/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuizQuestion(Guid id)
        {
            var quizQuestion = await _bll.QuizQuestions.FirstOrDefaultAsync(id);
            if (quizQuestion == null)
            {
                return NotFound();
            }

            await _bll.QuizQuestions.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> QuizQuestionExists(Guid id)
        {
            return _bll.QuizQuestions.ExistsAsync(id);
        }
    }
}
