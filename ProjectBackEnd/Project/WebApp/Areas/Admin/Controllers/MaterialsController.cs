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
using Material = App.DAL.DTO.Material;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MaterialsController : Controller
    {
        private readonly IAppBLL _bll;
        private readonly MaterialMapper _mapper;

        public MaterialsController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new MaterialMapper(mapper);
        }

        // GET: Admin/Materials
        public async Task<IActionResult> Index()
        {
            var result = await _bll.Materials.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/Materials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var res = await _bll.Materials.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/Materials/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description");
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description");
            return View();
        }

        // POST: Admin/Materials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( App.DTO.v1.Material material)
        {
            if (ModelState.IsValid)
            {
                material.Id = Guid.NewGuid();
                _bll.Materials.Add(_mapper.Map(material));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", material.CategoryId);
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", material.FileTypeId);
            return View(material);
        }

        // GET: Admin/Materials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _bll.Materials.FirstOrDefaultAsync(id.Value);
            if (material == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", material.CategoryId);
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", material.FileTypeId);
            return View(_mapper.Map(material));
        }

        // POST: Admin/Materials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.Material material)
        {
            if (id != material.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.Materials.Update(_mapper.Map(material));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await MaterialExists(material.Id))
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
            ViewData["CategoryId"] = new SelectList(await _bll.Categories.GetAllAsync(), "Id", "Description", material.CategoryId);
            ViewData["FileTypeId"] = new SelectList(await _bll.FileTypes.GetAllAsync(), "Id", "Description", material.FileTypeId);
            return View(material);
        }

        // GET: Admin/Materials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var res = await _bll.Materials.RemoveAsync(id.Value);
                


            return View(_mapper.Map(res));
        }

        // POST: Admin/Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var material = await _bll.Materials.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> MaterialExists(Guid id)
        {
            return _bll.Materials.ExistsAsync(id);
        }
    }
}
