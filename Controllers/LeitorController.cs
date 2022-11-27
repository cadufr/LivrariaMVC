using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class LeitorController : Controller
{
    private readonly LivrariaContext _context;
    public LeitorController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Leitor);
    }

    public IActionResult Show(int id)
    {
        Leitor leitor = _context.Leitor.Find(id);

        if(leitor == null)
        {
            return NotFound();
        }

        return View(leitor);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Leitor leitor)
    {
        if(!ModelState.IsValid) 
        {
            return View(leitor);
        }

        _context.Leitor.Add(leitor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Leitor leitor = _context.Leitor.Find(id);

        if(leitor == null)
        {
            return NotFound();
        }

        return View(leitor);
    }

    [HttpPost]
    public IActionResult Update(Leitor leitor, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(leitor);
        }
        
        Leitor updateLeitor = _context.Leitor.Find(leitor.Id);
        
        updateLeitor.Nome = leitor.Nome;
        updateLeitor.Idade = leitor.Idade;

        _context.Leitor.Update(updateLeitor);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Leitor leitor = _context.Leitor.Find(id);

        if(leitor == null)
        {
            return NotFound();
        }
        
        _context.Leitor.Remove(_context.Leitor.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}

