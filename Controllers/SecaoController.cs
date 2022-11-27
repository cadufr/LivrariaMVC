using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livraria.Models;

namespace Livraria.Controllers;

public class SecaoController : Controller
{
    private readonly LivrariaContext _context;
    public SecaoController(LivrariaContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Secao);
    }

    public IActionResult Show(int id)
    {
        Secao secao = _context.Secao.Find(id);

        if(secao == null)
        {
            return NotFound();
        }

        return View(secao);
    }

    [HttpGet]
    public IActionResult Cadastro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastro(Secao secao)
    {
        if(!ModelState.IsValid) 
        {
            return View(secao);
        }

        _context.Secao.Add(secao);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Secao secao = _context.Secao.Find(id);

        if(secao == null)
        {
            return NotFound();
        }

        return View(secao);
    }

    [HttpPost]
    public IActionResult Update(Secao secao, int id)
    {
        if(!ModelState.IsValid) 
        {
            return View(secao);
        }
        
        Secao updateSecao = _context.Secao.Find(secao.Id);
        
        updateSecao.Nome = secao.Nome;
        updateSecao.Descricao = secao.Descricao;

        _context.Secao.Update(updateSecao);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        Secao secao = _context.Secao.Find(id);

        if(secao == null)
        {
            return NotFound();
        }
        
        _context.Secao.Remove(_context.Secao.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

}

