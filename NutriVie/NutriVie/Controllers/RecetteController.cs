
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NutriVie.Models;
using NutriVie.Models.NutriVieEF;

public class RecetteController : Controller
{
    private readonly NutriVieDbContext _context;

    public RecetteController(NutriVieDbContext context)
    {
        _context = context;
    }

    // GET: RECETTES
    public async Task<IActionResult> Index()    
    {

        return View(await _context.Recettes.Include(r=>r.Categorie).OrderBy(r=>r.Categorie.Nom).ThenBy(r=>r.Nom).ToListAsync());
    }

    // GET: RECETTES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recette = await _context.Recettes.Include(r=>r.Categorie)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recette == null)
        {
            return NotFound();
        }

        return View(recette);
    }

    // GET: RECETTES/Create
    public IActionResult Create()
    {
        ViewData["CategorieId"] = new SelectList(
            _context.Categories,
            "Id",
            "Nom"
        );

        return View();
    }

    // POST: RECETTES/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Nom,Description,TempsPreparation,TempsCuisson,Image,CategorieId")]
    Recette recette)
    {
        if (ModelState.IsValid)
        {
            _context.Add(recette);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["CategorieId"] = new SelectList(
            _context.Categories,
            "Id",
            "Nom",
            recette.CategorieId
        );

        return View(recette);
    }

    // GET: RECETTES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recette = await _context.Recettes.FindAsync(id);

        if (recette == null)
        {
            return NotFound();
        }

        ViewData["CategorieId"] = new SelectList(
            _context.Categories,
            "Id",
            "Nom",
            recette.CategorieId
        );

        return View(recette);
    }

    // POST: RECETTES/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int? id,
        [Bind("Id,Nom,Description,TempsPreparation,TempsCuisson,Image,CategorieId")]
    Recette recette)
    {
        if (id != recette.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(recette);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetteExists(recette.Id))
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

        // Important si le ModelState n'est pas valide
        ViewData["CategorieId"] = new SelectList(
            _context.Categories,
            "Id",
            "Nom",
            recette.CategorieId
        );

        return View(recette);
    }

    // GET: RECETTES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var recette = await _context.Recettes.Include(r=>r.Categorie)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (recette == null)
        {
            return NotFound();
        }

        return View(recette);
    }

    // POST: RECETTES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var recette = await _context.Recettes.FindAsync(id);
        if (recette != null)
        {
            _context.Recettes.Remove(recette);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RecetteExists(int? id)
    {
        return _context.Recettes.Any(e => e.Id == id);
    }
}
