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
using Category = App.DAL.DTO.Category;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly CategoryMapper _mapper;

        public CategoriesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new CategoryMapper(mapper);
        }

        // GET: Admin/Categories
        public async Task<IActionResult> Index()
        {
            var result = await _bll.Categories.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.Categories.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/Categories/Create
        public async Task<IActionResult> Create()
        {
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id");
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                _bll.Categories.Add(_mapper.Map(category));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", category.AppUserId);
            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _bll.Categories.FirstOrDefaultAsync(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", category.AppUserId);
            return View(_mapper.Map(category));
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Categories.Update(_mapper.Map(category));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CategoryExists(category.Id))
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
            ViewData["AppUserId"] = new SelectList(await _bll.AppUsers.GetAllAsync(), "Id", "Id", category.AppUserId);
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.Categories
                .RemoveAsync(id.Value);
            

            return View(_mapper.Map(res));
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _bll.Categories.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> CategoryExists(Guid id)
        {
            return _bll.Categories.ExistsAsync(id);
        }
    }
}
