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
using QuizType = App.DAL.DTO.QuizType;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuizTypesController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly QuizTypeMapper _mapper;


        public QuizTypesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new QuizTypeMapper(mapper);
        }

        // GET: Admin/QuizTypes
        public async Task<IActionResult> Index()
        {
            var result = await _bll.QuizTypes.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/QuizTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.QuizTypes.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/QuizTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/QuizTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
             App.DTO.v1.QuizType quizType)
        {
            if (ModelState.IsValid)
            {
                quizType.Id = Guid.NewGuid();
                Console.WriteLine(quizType.ToString());
                _bll.QuizTypes.Add(_mapper.Map(quizType));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(quizType);
        }

        // GET: Admin/QuizTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizType = await _bll.QuizTypes.FirstOrDefaultAsync(id.Value);
            if (quizType == null)
            {
                return NotFound();
            }

            return View(_mapper.Map(quizType));
        }

        // POST: Admin/QuizTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
             App.DTO.v1.QuizType quizType)
        {
            if (id != quizType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.QuizTypes.Update(_mapper.Map(quizType));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuizTypeExists(quizType.Id))
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

            return View(quizType);
        }

        // GET: Admin/QuizTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.QuizTypes
                .RemoveAsync(id.Value);            

            return View(_mapper.Map(res));
        }

        // POST: Admin/QuizTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quizType = await _bll.QuizTypes.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> QuizTypeExists(Guid id)
        {
            return _bll.QuizTypes.ExistsAsync(id);
        }
    }
}