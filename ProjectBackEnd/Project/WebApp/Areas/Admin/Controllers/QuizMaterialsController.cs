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
using QuizMaterial = App.DAL.DTO.QuizMaterial;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuizMaterialsController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly QuizMaterialMapper _mapper;


        public QuizMaterialsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new QuizMaterialMapper(mapper);
        }

        // GET: Admin/QuizMaterials
        public async Task<IActionResult> Index()
        {
            var result = await _bll.QuizMaterials.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/QuizMaterials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.QuizMaterials.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/QuizMaterials/Create
        public async Task<IActionResult> Create()
        {
            ViewData["MaterialId"] = new SelectList(await _bll.Materials.GetAllAsync(), "Id", "Description");
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/QuizMaterials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( App.DTO.v1.QuizMaterial quizMaterial)
        {
            if (ModelState.IsValid)
            {
                quizMaterial.Id = Guid.NewGuid();
                _bll.QuizMaterials.Add(_mapper.Map(quizMaterial));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaterialId"] = new SelectList(await _bll.Materials.GetAllAsync(), "Id", "Description", quizMaterial.MaterialId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizMaterial.QuizId);
            return View(quizMaterial);
        }

        // GET: Admin/QuizMaterials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quizMaterial = await _bll.QuizMaterials.FirstOrDefaultAsync(id.Value);
            if (quizMaterial == null)
            {
                return NotFound();
            }
            ViewData["MaterialId"] = new SelectList(await _bll.Materials.GetAllAsync(), "Id", "Description", quizMaterial.MaterialId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizMaterial.QuizId);
            return View(_mapper.Map(quizMaterial));
        }

        // POST: Admin/QuizMaterials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,  App.DTO.v1.QuizMaterial quizMaterial)
        {
            if (id != quizMaterial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.QuizMaterials.Update(_mapper.Map(quizMaterial));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await QuizMaterialExists(quizMaterial.Id))
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
            ViewData["MaterialId"] = new SelectList(await _bll.Materials.GetAllAsync(), "Id", "Description", quizMaterial.MaterialId);
            ViewData["QuizId"] = new SelectList(await _bll.Quizzes.GetAllAsync(), "Id", "Description", quizMaterial.QuizId);
            return View(quizMaterial);
        }

        // GET: Admin/QuizMaterials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.QuizMaterials
                .RemoveAsync(id.Value);


            return View(_mapper.Map(res));
        }

        // POST: Admin/QuizMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var quizMaterial = await _bll.QuizMaterials.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> QuizMaterialExists(Guid id)
        {
            return _bll.QuizMaterials.ExistsAsync(id);
        }
    }
}
