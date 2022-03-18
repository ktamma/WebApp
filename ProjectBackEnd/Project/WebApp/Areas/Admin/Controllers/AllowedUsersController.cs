#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Contracts.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.DAL;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using App.DAL.Repositories;
using App.Domain;
using App.Public.Mappers;
using AutoMapper;
using AllowedUser = App.DAL.DTO.AllowedUser;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AllowedUsersController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly AllowedUserMapper _mapper;


        public AllowedUsersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new AllowedUserMapper(mapper);
        }

        // GET: Admin/AllowedUsers
        public async Task<IActionResult> Index()
        {
            var result = await _bll.AllowedUsers.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/AllowedUsers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var res = await _bll.AllowedUsers.FirstOrDefaultAsync(id);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/AllowedUsers/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id");
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/AllowedUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.AllowedUser allowedUser)
        {
            if (ModelState.IsValid)
            {
                allowedUser.Id = Guid.NewGuid();
                _bll.AllowedUsers.Add(_mapper.Map(allowedUser));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id");
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(false), "Id", "Description", allowedUser.QuizId);
            return View(allowedUser);
        }

        // GET: Admin/AllowedUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allowedUser = await _bll.AllowedUsers.FirstOrDefaultAsync(id.Value);
            if (allowedUser == null)
            {
                return NotFound();
            }

            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", allowedUser.AppUserId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", allowedUser.QuizId);
            return View(_mapper.Map(allowedUser));
        }

        // POST: Admin/AllowedUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.AllowedUser allowedUser)
        {
            if (id != allowedUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.AllowedUsers.Update(_mapper.Map(allowedUser));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AllowedUserExists(allowedUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", allowedUser.AppUserId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", allowedUser.QuizId);
            return View(allowedUser);
        }

        // GET: Admin/AllowedUsers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _bll.AllowedUsers.RemoveAsync(id);
            
            return View(_mapper.Map(res));
        }

        // POST: Admin/AllowedUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var allowedUser = await _bll.AllowedUsers.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> AllowedUserExists(Guid id)
        {
            return _bll.AllowedUsers.ExistsAsync(id);
        }
    }
}