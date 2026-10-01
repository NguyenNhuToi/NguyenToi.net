using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nnt_TvcLesson12.Models;

namespace Nnt_TvcLesson12.Controllers
{
    public class NntProductsController : Controller
    {
        private readonly NntTvcLesson12Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public NntProductsController(NntTvcLesson12Context context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: NntProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.NntProducts.ToListAsync());
        }

        // GET: NntProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var nntProduct = await _context.NntProducts
                .FirstOrDefaultAsync(m => m.NntId == id.Value);
            if (nntProduct == null) return NotFound();

            return View(nntProduct);
        }

        // GET: NntProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NntProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NntId,NntName,NntImage,NntPrice,NntSalePrice,NntStatus,NntDescriptions,NntCreatedDate,NntCategoryId,NntImageFile")] NntProduct nntProduct)
        {
            if (ModelState.IsValid)
            {
                // === XỬ LÝ UPLOAD ẢNH ===
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = Path.GetFileName(file.FileName); // Lấy đúng tên file, tránh path injection
                    var folderPath = Path.Combine(_hostEnvironment.WebRootPath, "Nnt_Product");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    var fullPath = Path.Combine(folderPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    nntProduct.NntImage = fileName;
                }
                // === KẾT THÚC UPLOAD ===

                _context.Add(nntProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nntProduct);
        }

        // GET: NntProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var nntProduct = await _context.NntProducts.FindAsync(id.Value);
            if (nntProduct == null) return NotFound();

            return View(nntProduct);
        }

        // POST: NntProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NntId,NntName,NntImage,NntPrice,NntSalePrice,NntStatus,NntDescriptions,NntCreatedDate,NntCategoryId,NntImageFile")] NntProduct nntProduct)
        {
            if (id != nntProduct.NntId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // === XỬ LÝ UPLOAD ẢNH MỚI (NẾU CÓ) ===
                    var files = HttpContext.Request.Form.Files;
                    if (files.Count > 0 && files[0].Length > 0)
                    {
                        var file = files[0];
                        var fileName = Path.GetFileName(file.FileName);
                        var folderPath = Path.Combine(_hostEnvironment.WebRootPath, "Nnt_Product");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        var fullPath = Path.Combine(folderPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        nntProduct.NntImage = fileName;
                    }
                    // === KẾT THÚC ===

                    _context.Update(nntProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NntProductExists(nntProduct.NntId)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nntProduct);
        }

        // GET: NntProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var nntProduct = await _context.NntProducts
                .FirstOrDefaultAsync(m => m.NntId == id.Value);
            if (nntProduct == null) return NotFound();

            return View(nntProduct);
        }

        // POST: NntProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nntProduct = await _context.NntProducts.FindAsync(id);
            if (nntProduct != null)
            {
                _context.NntProducts.Remove(nntProduct);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NntProductExists(int id)
        {
            return _context.NntProducts.Any(e => e.NntId == id);
        }
    }
}