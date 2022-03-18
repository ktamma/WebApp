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
using Quiz = App.DAL.DTO.Quiz;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuizzesController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly QuizMapper _mapper;


        public QuizzesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new QuizMapper(mapper);
        }

        // GET: Admin/Quizzes
        public async Task<IActionResult> Index()
        {
            var result = await _bll.Quizzes.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/Quizzes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.Quizzes.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/Quizzes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description");
            ViewData["QuizTypeId"] = new SelectList(await _bll.QuizTypes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/Quizzes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.Quiz quiz)
        {
            if (ModelState.IsValid)
            {
                quiz.Id = Guid.NewGuid();
                _bll.Quizzes.Add(_mapper.Map(quiz));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", quiz.CategoryId);
            ViewData["QuizTypeId"] = new SelectList(await _bll.QuizTypes.GetAllAsync(), "Id", "Description", quiz.QuizTypeId);
            return View(quiz);
        }

        // GET: Admin/Quizzes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quiz = await _bll.Quizzes.FirstOrDefaultAsync(id.Value);
            if (quiz == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", quiz.CategoryId);
            ViewData["QuizTypeId"] = new SelectList(await _bll.QuizTypes.GetAllAsync(), "Id", "Description", quiz.QuizTypeId);
            return View(_mapper.Map(quiz));
        }

        // POST: Admin/Quizzes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  App.DTO.v1.Quiz quiz)
        {
            if (id != quiz.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Quizzes.Update(_mapper.Map(quiz));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuizExists(quiz.Id))
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
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", quiz.CategoryId);
            ViewData["QuizTypeId"] = new SelectList(await _bll.QuizTypes.GetAllAsync(), "Id", "Description", quiz.QuizTypeId);
            return View(quiz);
        }

        // GET: Admin/Quizzes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.Quizzes
                .RemoveAsync(id.Value);


            return View(_mapper.Map(res));
        }

        // POST: Admin/Quizzes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quiz = await _bll.Quizzes.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> QuizExists(Guid id)
        {
            return _bll.Quizzes.ExistsAsync(id);
        }
    }
}
