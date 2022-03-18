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
    /// Public Controller for quizzes, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly QuizMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public QuizzesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.QuizMapper(mapper);
        }

        // GET: api/Quizzes
        /// <summary>
        /// Get all quizzes
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.Quiz>>> GetQuizzes()
        {
            return Ok((await _bll.Quizzes.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/Quizzes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.Quiz>> GetQuiz(Guid id)
        {
            var quiz = await _bll.Quizzes.FirstOrDefaultAsync(id);

            if (quiz == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(quiz));
        }

        // PUT: api/Quizzes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quiz"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuiz(Guid id, App.DTO.v1.Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return BadRequest();
            }

            _bll.Quizzes.Update(_mapper.Map(quiz));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await QuizExists(id))
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

        // POST: api/Quizzes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="quiz"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.Quiz>> PostQuiz(App.DTO.v1.Quiz quiz)
        {
            _bll.Quizzes.Add(_mapper.Map(quiz));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetQuiz", new { id = quiz.Id }, quiz);
        }

        // DELETE: api/Quizzes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuiz(Guid id)
        {
            var quiz = await _bll.Quizzes.FirstOrDefaultAsync(id);
            if (quiz == null)
            {
                return NotFound();
            }

            _bll.Quizzes.Remove(quiz);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> QuizExists(Guid id)
        {
            return _bll.Quizzes.ExistsAsync(id);
        }
    }
}
