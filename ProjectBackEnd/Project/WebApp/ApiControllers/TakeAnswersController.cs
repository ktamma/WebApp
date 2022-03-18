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
    /// Public Controller for take answers, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TakeAnswersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly TakeAnswerMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public TakeAnswersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.TakeAnswerMapper(mapper);
        }

        // GET: api/TakeAnswers
        /// <summary>
        /// Get all take answers
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.TakeAnswer>>> GetTakeAnswers()
        {
            return Ok((await _bll.TakeAnswers.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/TakeAnswers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.TakeAnswer>> GetTakeAnswer(Guid id)
        {
            var takeAnswer = await _bll.TakeAnswers.FirstOrDefaultAsync(id);

            if (takeAnswer == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(takeAnswer));
        }

        // PUT: api/TakeAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="takeAnswer"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTakeAnswer(Guid id, App.DTO.v1.TakeAnswer takeAnswer)
        {
            if (id != takeAnswer.Id)
            {
                return BadRequest();
            }

            _bll.TakeAnswers.Update(_mapper.Map(takeAnswer));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TakeAnswerExists(id))
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

        // POST: api/TakeAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="takeAnswer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.TakeAnswer>> PostTakeAnswer(App.DTO.v1.TakeAnswer takeAnswer)
        {
            _bll.TakeAnswers.Add(_mapper.Map(takeAnswer));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTakeAnswer", new { id = takeAnswer.Id }, takeAnswer);
        }

        // DELETE: api/TakeAnswers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTakeAnswer(Guid id)
        {
            var takeAnswer = await _bll.TakeAnswers.FirstOrDefaultAsync(id);
            if (takeAnswer == null)
            {
                return NotFound();
            }

            await _bll.TakeAnswers.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> TakeAnswerExists(Guid id)
        {
            return _bll.TakeAnswers.ExistsAsync(id);
        }
    }
}
