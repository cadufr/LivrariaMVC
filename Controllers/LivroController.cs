using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class LivroController : Controller
{
    private readonly LivrariaContext _context;
    public LivroController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Livro);
    }

    public IActionResult Show(int id)
    {
        Livro livro = _context.Livro.Find(id);

        if(livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Livro livro)
    {
        if(!ModelState.IsValid) 
        {
            return View(livro);
        }

        _context.Livro.Add(livro);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Livro livro = _context.Livro.Find(id);

        if(livro == null)
        {
            return NotFound();
        }

        return View(livro);
    }

    [HttpPost]
    public IActionResult Update(Livro livro, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(livro);
        }
        
        Livro updateLivro = _context.Livro.Find(livro.Id);
        
        updateLivro.Nome = livro.Nome;
        updateLivro.Descricao = livro.Descricao;

        _context.Livro.Update(updateLivro);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Livro livro = _context.Livro.Find(id);

        if(livro == null)
        {
            return NotFound();
        }
        
        _context.Livro.Remove(_context.Livro.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}
