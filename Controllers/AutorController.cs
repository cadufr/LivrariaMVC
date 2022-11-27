using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class CategoriaController : Controller
{
    private readonly LivrariaContext _context;
    public CategoriaController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Categoria);
    }

    public IActionResult Show(int id)
    {
        Categoria Categoria = _context.Categoria.Find(id);

        if(Categoria == null)
        {
            return NotFound();
        }

        return View(Categoria);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Categoria categoria)
    {
        if(!ModelState.IsValid) 
        {
            return View(categoria);
        }

        _context.Categoria.Add(categoria);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Categoria categoria = _context.Categoria.Find(id);

        if(categoria == null)
        {
            return NotFound();
        }

        return View(categoria);
    }

    [HttpPost]
    public IActionResult Update(Categoria categoria, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(categoria);
        }
        
        Categoria updateCategoria = _context.Categoria.Find(categoria.Id);
        
        updateCategoria.Nome = categoria.Nome;
        updateCategoria.Descricao = categoria.Descricao;

        _context.Categoria.Update(updateCategoria);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Categoria categoria = _context.Categoria.Find(id);

        if(categoria == null)
        {
            return NotFound();
        }
        
        _context.Categoria.Remove(_context.Categoria.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}


