
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.NutriVieEF;

public class CategorieController : Controller
{
    private readonly NutriVieDbContext _context;

    public CategorieController(NutriVieDbContext context)
    {
        _context = context;
    }

    // GET: CATEGORIES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Categories.Include(r=>r.Recette).OrderByDescending(r=>r.Nom).ToListAsync());
    }

    // GET: CATEGORIES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // GET: CATEGORIES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CATEGORIES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Nom,Recette")] Categorie categorie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(categorie);
    }

    // GET: CATEGORIES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null)
        {
            return NotFound();
        }
        return View(categorie);
    }

    // POST: CATEGORIES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Nom,Recette")] Categorie categorie)
    {
        if (id != categorie.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(categorie);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(categorie.Id))
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
        return View(categorie);
    }

    // GET: CATEGORIES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var categorie = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == id);
        if (categorie == null)
        {
            return NotFound();
        }

        return View(categorie);
    }

    // POST: CATEGORIES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var categorie = await _context.Categories.FindAsync(id);
        if (categorie != null)
        {
            _context.Categories.Remove(categorie);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CategorieExists(int? id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}
