using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenNhuToi2410900075_exam.Models;

namespace NguyenNhuToi2410900075_exam.Controllers
{
    public class NntMembersController : Controller
    {
        private readonly NntStudent2410900075DbContext _context;

        public NntMembersController(NntStudent2410900075DbContext context)
        {
            _context = context;
        }

        // GET: NntMembers
        public async Task<IActionResult> Index()
        {
            return View(await _context.NntMembers.ToListAsync());
        }

        // GET: NntMembers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nntMember = await _context.NntMembers
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (nntMember == null)
            {
                return NotFound();
            }

            return View(nntMember);
        }

        // GET: NntMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NntMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NntName,NntGender,NntBirthDay,NntEmail,NntPhone,NntActive")] NntMember nntMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nntMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nntMember);
        }

        // GET: NntMembers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nntMember = await _context.NntMembers.FindAsync(id.Value);
            if (nntMember == null)
            {
                return NotFound();
            }
            return View(nntMember);
        }

        // POST: NntMembers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,NntName,NntGender,NntBirthDay,NntEmail,NntPhone,NntActive")] NntMember nntMember)
        {
            if (id != nntMember.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nntMember);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NntMemberExists(nntMember.Id))
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
            return View(nntMember);
        }

        // GET: NntMembers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nntMember = await _context.NntMembers
                .FirstOrDefaultAsync(m => m.Id == id.Value);
            if (nntMember == null)
            {
                return NotFound();
            }

            return View(nntMember);
        }

        // POST: NntMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var nntMember = await _context.NntMembers.FindAsync(id);
            if (nntMember != null)
            {
                _context.NntMembers.Remove(nntMember);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NntMemberExists(long id)
        {
            return _context.NntMembers.Any(e => e.Id == id);
        }
    }
}
