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
using QuizQuestion = App.DAL.DTO.QuizQuestion;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuizQuestionsController : Controller
    {

        private readonly IAppBLL _bll;
        private readonly QuizQuestionMapper _mapper;

        public QuizQuestionsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new QuizQuestionMapper(mapper);
        }

        // GET: Admin/QuizQuestions
        public async Task<IActionResult> Index()
        {
            var result = await _bll.QuizQuestions.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/QuizQuestions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.QuizQuestions.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/QuizQuestions/Create
        public async Task<IActionResult> Create()
        {
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/QuizQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( App.DTO.v1.QuizQuestion quizQuestion)
        {
            if (ModelState.IsValid)
            {
                quizQuestion.Id = Guid.NewGuid();
                _bll.QuizQuestions.Add(_mapper.Map(quizQuestion));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: Admin/QuizQuestions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizQuestion = await _bll.QuizQuestions.FirstOrDefaultAsync(id.Value);
            if (quizQuestion == null)
            {
                return NotFound();
            }
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizQuestion.QuizId);
            return View(_mapper.Map(quizQuestion));
        }

        // POST: Admin/QuizQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.QuizQuestion quizQuestion)
        {
            if (id != quizQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.QuizQuestions.Update(_mapper.Map(quizQuestion));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await QuizQuestionExists(quizQuestion.Id))
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
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizQuestion.QuizId);
            return View(quizQuestion);
        }

        // GET: Admin/QuizQuestions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.QuizQuestions
                .RemoveAsync(id.Value);


            return View(_mapper.Map(res));
        }

        // POST: Admin/QuizQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quizQuestion = await _bll.QuizQuestions.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> QuizQuestionExists(Guid id)
        {
            return _bll.QuizQuestions.ExistsAsync(id);
        }
    }
}
