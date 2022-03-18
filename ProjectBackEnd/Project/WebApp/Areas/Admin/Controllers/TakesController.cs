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
using Take = App.DAL.DTO.Take;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TakesController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly TakeMapper _mapper;

        public TakesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new TakeMapper(mapper);
        }

        // GET: Admin/Takes
        public async Task<IActionResult> Index()
        {
            var result = await _bll.Takes.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/Takes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.Takes.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/Takes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id");
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/Takes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.Take take)
        {
            if (ModelState.IsValid)
            {
                take.Id = Guid.NewGuid();
                _bll.Takes.Add(_mapper.Map(take));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", take.AppUserId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", take.QuizId);
            return View(take);
        }

        // GET: Admin/Takes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var take = await _bll.Takes.FirstOrDefaultAsync(id.Value);
            if (take == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", take.AppUserId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", take.QuizId);
            return View(_mapper.Map(take));
        }

        // POST: Admin/Takes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.Take take)
        {
            if (id != take.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Takes.Update(_mapper.Map(take));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TakeExists(take.Id))
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
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", take.AppUserId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", take.QuizId);
            return View(take);
        }

        // GET: Admin/Takes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.Takes
                .RemoveAsync(id.Value);

            return View(_mapper.Map(res));
        }

        // POST: Admin/Takes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var take = await _bll.Takes.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> TakeExists(Guid id)
        {
            return _bll.Takes.ExistsAsync(id);
        }
    }
}
