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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Public Controller for file types, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class FileTypesController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly FileTypeMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public FileTypesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.FileTypeMapper(mapper);
        }
        
        // GET: api/FileTypes
        /// <summary>
        /// Get all file types
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileType>>> GetFileTypes()
        {
            return Ok((await _bll.FileTypes.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/FileTypes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.FileType>> GetFileType(Guid id)
        {
            var fileType = await _bll.FileTypes.FirstOrDefaultAsync(id);

            if (fileType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(fileType));
        }

        // PUT: api/FileTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFileType(Guid id, App.DTO.v1.FileType fileType)
        {
            if (id != fileType.Id)
            {
                return BadRequest();
            }

            _bll.FileTypes.Update(_mapper.Map(fileType));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await FileTypeExists(id))
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

        // POST: api/FileTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileType"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.FileType>> PostFileType(App.DTO.v1.FileType fileType)
        {
            _bll.FileTypes.Add(_mapper.Map(fileType));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetFileType", new { id = fileType.Id }, fileType);
        }

        // DELETE: api/FileTypes/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFileType(Guid id)
        {
            var fileType = await _bll.FileTypes.FirstOrDefaultAsync(id);
            if (fileType == null)
            {
                return NotFound();
            }

            await _bll.FileTypes.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private Task<bool> FileTypeExists(Guid id)
        {
            return _bll.FileTypes.ExistsAsync(id);
        }
    }
}
