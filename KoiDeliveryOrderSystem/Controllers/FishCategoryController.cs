using KoiDeliveryOrderSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KoiDeliveryOrderSystem.Controllers
{
    public class FishCategoryController(Fa24Se1877211G3KoiDeliveryOrderSystemContext context) : Controller
    {
        private readonly Fa24Se1877211G3KoiDeliveryOrderSystemContext _context = context;

        public async Task<IActionResult> Index() => View(await _context.FishCategories.ToListAsync());

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var fishCategory = await _context.FishCategories.FirstOrDefaultAsync(m => m.FishTypeId == id);

            if (fishCategory == null) return NotFound();
            return View(fishCategory);
        }

        public IActionResult Create() => View();


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FishTypeId,FishName,MinSize,MaxSize,MinPrice,MaxPrice,Breed,Origin,IsActive")] FishCategory fishCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fishCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fishCategory);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var fishCategory = await _context.FishCategories.FindAsync(id);
            if (fishCategory == null) return NotFound();

            return View(fishCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FishTypeId,FishName,MinSize,MaxSize,MinPrice,MaxPrice,Breed,Origin,IsActive")] FishCategory fishCategory)
        {
            if (id != fishCategory.FishTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fishCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FishCategoryExists(fishCategory.FishTypeId))
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
            return View(fishCategory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var fishCategory = await _context.FishCategories.FirstOrDefaultAsync(m => m.FishTypeId == id);
            if (fishCategory == null) return NotFound();

            return View(fishCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fishCategory = await _context.FishCategories.FindAsync(id);
            if (fishCategory != null) _context.FishCategories.Remove(fishCategory);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FishCategoryExists(int id) => _context.FishCategories.Any(e => e.FishTypeId == id);
    }
}
