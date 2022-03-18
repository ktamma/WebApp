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
using App.Domain.Identity;
using AppUser = App.BLL.DTO.Identity.AppUser;
#pragma warning disable 1591

namespace WebApp.Areas.Admin.Controllers.Identity
{
    [Area("Admin")]
    public class AppUsersController : Controller
    {
        private readonly IAppBLL _bll;

        public AppUsersController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: Admin/AppUsers
        public async Task<IActionResult> Index()
        {
            return View(await _bll.AppUsers.GetAllAsync());
        }

        // GET: Admin/AppUsers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers
                .FirstOrDefaultAsync(id.Value);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // GET: Admin/AppUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AppUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                appUser.Id = Guid.NewGuid();
                _bll.AppUsers.Add(appUser);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: Admin/AppUsers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _bll.AppUsers.FirstOrDefaultAsync(id.Value);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        // POST: Admin/AppUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] App.BLL.DTO.Identity.AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bll.AppUsers.Update(appUser);
                    await _bll.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AppUserExists(appUser.Id))
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
            return View(appUser);
        }

        // GET: Admin/AppUsers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var res = await _bll.AppUsers.RemoveAsync(id.Value);
            
            return View(res);
        }

  

        // POST: Admin/AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appUser = await _bll.AppUsers.FirstOrDefaultAsync(id);
            _bll.AppUsers.Remove(appUser!);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private Task<bool> AppUserExists(Guid id)
        {
            return _bll.AppUsers.ExistsAsync( id);
        }
    }
}
