#nullable disable
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using App.Public.Mappers;
using AutoMapper;
using Category = App.DAL.DTO.Category;

namespace WebApp.ApiControllers
{
    /// <summary>
    /// Public Controller for Allowed Users, inherits from ControllerBase
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AllowedUsersController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly AllowedUserMapper _mapper;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bll">Business logic layer that uses Data access layer for database access</param>
        /// <param name="mapper">Mapper to map public DTO to business logic layer DTO</param>
        public AllowedUsersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new App.Public.Mappers.AllowedUserMapper(mapper);
        }

        /// <summary>
        /// Get all allowedUsers
        /// </summary>
        /// <returns>List of public DTO-s</returns>
        // GET: api/AllowedUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<App.DTO.v1.AllowedUser>>> GetAllowedUsers()
        {
            return Ok((await _bll.AllowedUsers.GetAllAsync()).Select(x=>_mapper.Map(x)));
        }

        // GET: api/AllowedUsers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<App.DTO.v1.AllowedUser>> GetAllowedUser(Guid id)
        {
            var allowedUser = await _bll.AllowedUsers.FirstOrDefaultAsync(id);

            if (allowedUser == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map(allowedUser));
        }

        // PUT: api/AllowedUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowedUser"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllowedUser(Guid id, App.DTO.v1.AllowedUser allowedUser)
        {
            if (id != allowedUser.Id)
            {
                return BadRequest();
            }

            
            _bll.AllowedUsers.Update(_mapper.Map(allowedUser));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await AllowedUserExists(id))
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

        // POST: api/AllowedUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allowedUser"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<App.DTO.v1.AllowedUser>> PostAllowedUser(App.DTO.v1.AllowedUser allowedUser)
        {
            _bll.AllowedUsers.Add(_mapper.Map(allowedUser));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetAllowedUser", new { id = allowedUser.Id }, allowedUser);
        }

        // DELETE: api/AllowedUsers/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllowedUser(Guid id)
        {
            var allowedUser = await _bll.AllowedUsers.FirstOrDefaultAsync(id);
            if (allowedUser == null)
            {
                return NotFound();
            }

            await _bll.AllowedUsers.RemoveAsync(id);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> AllowedUserExists(Guid id)
        {
            return await _bll.AllowedUsers.ExistsAsync(id);
        }
    }
}
