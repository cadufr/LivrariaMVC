using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class LivrariaController : Controller
{
    private readonly LivrariaContext _context;
    public LivrariaController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Autor);
    }

    public IActionResult Show(int id)
    {
        Autor autor = _context.Autor.Find(id);

        if(autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Autor autor)
    {
        if(!ModelState.IsValid) 
        {
            return View(autor);
        }

        _context.Autor.Add(autor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Autor autor = _context.Autor.Find(id);

        if(autor == null)
        {
            return NotFound();
        }

        return View(autor);
    }

    [HttpPost]
    public IActionResult Update(Autor autor, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(autor);
        }
        
        Autor updateAutor = _context.Autor.Find(autor.Id);
        
        updateAutor.Nome = autor.Nome;
        updateAutor.Idade = autor.Idade;

        _context.Autor.Update(updateAutor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Autor autor = _context.Autor.Find(id);

        if(autor == null)
        {
            return NotFound();
        }
        
        _context.Autor.Remove(_context.Autor.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
