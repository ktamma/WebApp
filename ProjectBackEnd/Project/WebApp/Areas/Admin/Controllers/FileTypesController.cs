#nullable disable
using App.Contracts.BLL;
using App.Public.Mappers;
using AutoMapper;
using Base.Contracts.Public.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileTypesController : Controller
    {
        private readonly IAppBLL _bll;
        // protected IMapper Mapper;
        private readonly FileTypeMapper _mapper;


        public FileTypesController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = new FileTypeMapper(mapper);
        }

        // GET: Admin/FileTypes
        public async Task<IActionResult> Index()
        {
            var result = await _bll.FileTypes.GetAllAsync();
            var res = result.Select(c => _mapper.Map(c));
            await _bll.SaveChangesAsync();
            return View(res);
        }

        // GET: Admin/FileTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {          
            var res = await _bll.FileTypes.FirstOrDefaultAsync(id!.Value);
            if (res == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(res));
        }

        // GET: Admin/FileTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/FileTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(App.DTO.v1.FileType fileType)
        {
            if (ModelState.IsValid)
            {
                fileType.Id = Guid.NewGuid();
                Console.WriteLine(fileType.Description + fileType.FileExtension);
                _bll.FileTypes.Add(_mapper.Map(fileType));
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fileType);
        }

        // GET: Admin/FileTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _bll.FileTypes.FirstOrDefaultAsync(id.Value);
            if (fileType == null)
            {
                return NotFound();
            }
            return View(_mapper.Map(fileType));
        }

        // POST: Admin/FileTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, App.DTO.v1.FileType fileType)
        {
            if (id != fileType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.FileTypes.Update(_mapper.Map(fileType));
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await FileTypeExists(fileType.Id))
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
            return View(fileType);
        }

        // GET: Admin/FileTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fileType = await _bll.FileTypes
                .RemoveAsync(id.Value);


            return View(_mapper.Map(fileType));
        }

        // POST: Admin/FileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fileType = await _bll.FileTypes.RemoveAsync(id);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> FileTypeExists(Guid id)
        {
            return _bll.FileTypes.ExistsAsync(id);
        }
    }
}
