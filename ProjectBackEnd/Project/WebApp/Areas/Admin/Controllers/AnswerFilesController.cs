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
using AnswerFile = App.DAL.DTO.AnswerFile;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnswerFilesController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly AnswerFileMapper _mapper;


        public AnswerFilesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new AnswerFileMapper(mapper);
        }

        // GET: Admin/AnswerFiles
        public async Task<IActionResult> Index()
        {
            var result = await _bll.AnswerFiles.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/AnswerFiles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.AnswerFiles.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/AnswerFiles/Create
        public async Task<IActionResult> Create()
        {
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description");
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content");
            return View();
        }

        // POST: Admin/AnswerFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.AnswerFile answerFile)
        {
            if (ModelState.IsValid)
            {
                answerFile.Id = Guid.NewGuid();
                _bll.AnswerFiles.Add(_mapper.Map(answerFile));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", answerFile.FileTypeId);
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", answerFile.QuizAnswerId);
            return View(answerFile);
        }

        // GET: Admin/AnswerFiles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var answerFile = await _bll.AnswerFiles.FirstOrDefaultAsync(id!.Value);
            if (answerFile == null)
            {
                return NotFound();
            }
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", answerFile.FileTypeId);
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", answerFile.QuizAnswerId);
            return View(_mapper.Map(answerFile));
        }

        // POST: Admin/AnswerFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.AnswerFile answerFile)
        {
            if (id != answerFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.AnswerFiles.Update(_mapper.Map(answerFile));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await AnswerFileExists(answerFile.Id))
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
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", answerFile.FileTypeId);
            ViewData["QuizAnswerId"] = new SelectList(await _bll.QuizAnswers.GetAllAsync(), "Id", "Content", answerFile.QuizAnswerId);
            return View(answerFile);
        }

        // GET: Admin/AnswerFiles/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _bll.AnswerFiles.RemoveAsync(id);
            
            return View(_mapper.Map(res));
        }

        // POST: Admin/AnswerFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var res = await _bll.AnswerFiles.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> AnswerFileExists(Guid id)
        {
            return _bll.AnswerFiles.ExistsAsync(id);
        }
    }
}
