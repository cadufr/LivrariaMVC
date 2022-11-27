using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class EditoraController : Controller
{
    private readonly LivrariaContext _context;
    public EditoraController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Editora);
    }

    public IActionResult Show(int id)
    {
        Editora Editora = _context.Editora.Find(id);

        if(Editora == null)
        {
            return NotFound();
        }

        return View(Editora);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Editora editora)
    {
        if(!ModelState.IsValid) 
        {
            return View(editora);
        }

        _context.Editora.Add(editora);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Editora editora = _context.Editora.Find(id);

        if(editora == null)
        {
            return NotFound();
        }

        return View(editora);
    }

    [HttpPost]
    public IActionResult Update(Editora editora, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(editora);
        }
        
        Editora updateEditora = _context.Editora.Find(editora.Id);
        
        updateEditora.Nome = editora.Nome;
        updateEditora.Descricao = editora.Descricao;

        _context.Editora.Update(updateEditora);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Editora editora = _context.Editora.Find(id);

        if(editora == null)
        {
            return NotFound();
        }
        
        _context.Editora.Remove(_context.Editora.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}

