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
using TakeAnswer = App.DAL.DTO.TakeAnswer;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TakeAnswersController : Controller
    {

        private readonly IAppBLL _bll;
        private readonly TakeAnswerMapper _mapper;

        public TakeAnswersController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new TakeAnswerMapper(mapper);
        }

        // GET: Admin/TakeAnswers
        public async Task<IActionResult> Index()
        {
            var result = await _bll.TakeAnswers.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/TakeAnswers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.TakeAnswers.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/TakeAnswers/Create
        public async Task<IActionResult> Create()
        {
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content");
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content");
            ViewData["TakeId"] = new SelectList(await _bll.Takes.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: Admin/TakeAnswers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( App.DTO.v1.TakeAnswer takeAnswer)
        {
            if (ModelState.IsValid)
            {
                takeAnswer.Id = Guid.NewGuid();
                _bll.TakeAnswers.Add(_mapper.Map(takeAnswer));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", takeAnswer.QuizAnswerId);
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", takeAnswer.QuizQuestionId);
            ViewData["TakeId"] = new SelectList(await _bll.Takes.GetAllAsync(), "Id", "Id", takeAnswer.TakeId);
            return View(takeAnswer);
        }

        // GET: Admin/TakeAnswers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var takeAnswer = await _bll.TakeAnswers.FirstOrDefaultAsync(id.Value);
            if (takeAnswer == null)
            {
                return NotFound();
            }
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", takeAnswer.QuizAnswerId);
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", takeAnswer.QuizQuestionId);
            ViewData["TakeId"] = new SelectList(await _bll.Takes.GetAllAsync(), "Id", "Id", takeAnswer.TakeId);
            return View(_mapper.Map(takeAnswer));
        }

        // POST: Admin/TakeAnswers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  App.DTO.v1.TakeAnswer takeAnswer)
        {
            if (id != takeAnswer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.TakeAnswers.Update(_mapper.Map(takeAnswer));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await TakeAnswerExists(takeAnswer.Id))
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
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", takeAnswer.QuizAnswerId);
            ViewData["QuizQuestionId"] = new SelectList(await _bll.QuizQuestions.GetAllAsync(), "Id", "Content", takeAnswer.QuizQuestionId);
            ViewData["TakeId"] = new SelectList(await _bll.Takes.GetAllAsync(), "Id", "Id", takeAnswer.TakeId);
            return View(takeAnswer);
        }

        // GET: Admin/TakeAnswers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.TakeAnswers
                .RemoveAsync(id.Value);


            return View(_mapper.Map(res));
        }

        // POST: Admin/TakeAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var takeAnswer = await _bll.TakeAnswers.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> TakeAnswerExists(Guid id)
        {
            return _bll.TakeAnswers.ExistsAsync(id);
        }
    }
}
