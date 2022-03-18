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
    /// Public Controller for answer files, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AnswerFilesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly AnswerFileMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public AnswerFilesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.AnswerFileMapper(mapper);
        }

        // GET: api/AnswerFiles
        /// <summary>
        /// Get all answer files
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.AnswerFile>>> GetAnswerFiles()
        {
            return Ok((await _bll.AnswerFiles.GetAllAsync()).Select(x => _mapper.Map(x)));
        }

        // GET: api/AnswerFiles/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.AnswerFile>> GetAnswerFile(Guid id)
        {
            var answerFile = await _bll.AnswerFiles.FirstOrDefaultAsync(id);

            if (answerFile == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(answerFile));
        }

        // PUT: api/AnswerFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="answerFile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnswerFile(Guid id, App.DTO.v1.AnswerFile answerFile)
        {
            if (id != answerFile.Id)
            {
                return BadRequest();
            }

            _bll.AnswerFiles.Update(_mapper.Map(answerFile));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await AnswerFileExists(id))
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

        // POST: api/AnswerFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="answerFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.AnswerFile>> PostAnswerFile(App.DTO.v1.AnswerFile answerFile)
        {
            _bll.AnswerFiles.Add(_mapper.Map(answerFile));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAnswerFile", new { id = answerFile.Id }, answerFile);
        }

        // DELETE: api/AnswerFiles/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerFile(Guid id)
        {
            var answerFile = await _bll.AnswerFiles.FirstOrDefaultAsync(id);
            if (answerFile == null)
            {
                return NotFound();
            }

            await _bll.AllowedUsers.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> AnswerFileExists(Guid id)
        {
            return _bll.AnswerFiles.ExistsAsync(id);
        }
    }
}