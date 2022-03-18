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
using QuizAnswer = App.DAL.DTO.QuizAnswer;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuizAnswersController : Controller
    {

        private readonly IAppBLL _bll;
        private readonly QuizAnswerMapper _mapper;

        public QuizAnswersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new QuizAnswerMapper(mapper);
        }

        // GET: Admin/QuizAnswers
        public async Task<IActionResult> Index()
        {
            var result = await _bll.QuizAnswers.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/QuizAnswers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.QuizAnswers.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/QuizAnswers/Create
        public async Task<IActionResult> Create()
        {
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content");
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/QuizAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.QuizAnswer quizAnswer)
        {
            if (ModelState.IsValid)
            {
                quizAnswer.Id = Guid.NewGuid();
                _bll.QuizAnswers.Add(_mapper.Map(quizAnswer));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", quizAnswer.QuizQuestionId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizAnswer.QuizId);
            return View(quizAnswer);
        }

        // GET: Admin/QuizAnswers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizAnswer = await _bll.QuizAnswers.FirstOrDefaultAsync(id.Value);
            if (quizAnswer == null)
            {
                return NotFound();
            }
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", quizAnswer.QuizQuestionId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizAnswer.QuizId);
            return View(_mapper.Map(quizAnswer));
        }

        // POST: Admin/QuizAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.QuizAnswer quizAnswer)
        {
            if (id != quizAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.QuizAnswers.Update(_mapper.Map(quizAnswer));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuizAnswerExists(quizAnswer.Id))
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
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", quizAnswer.QuizQuestionId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizAnswer.QuizId);
            return View(quizAnswer);
        }

        // GET: Admin/QuizAnswers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.QuizAnswers
                .RemoveAsync(id.Value);


            return View(_mapper.Map(res));
        }

        // POST: Admin/QuizAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quizAnswer = await _bll.QuizAnswers.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> QuizAnswerExists(Guid id)
        {
            return _bll.QuizAnswers.ExistsAsync(id);
        }
    }
}
