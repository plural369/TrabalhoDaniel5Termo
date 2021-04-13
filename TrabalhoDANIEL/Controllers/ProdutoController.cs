using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrabalhoDANIEL.Data;
using TrabalhoDANIEL.Models;

namespace TrabalhoDANIEL.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly Context _context;

        public ProdutoController(Context context){
                _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.produto.ToListAsync());
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create([Bind("Nome","Valor","Descricao","Peso","Cor")] Produto produto )
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.produto.Add(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Erro ao cadastrar");
            }
            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            return  View(await _context.produto.FirstOrDefaultAsync(c => c.Id == id));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(await _context.produto.FirstOrDefaultAsync(c => c.Id == id));
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id","Nome","Valor","Descricao","Peso","Cor")] Produto produto)
        {
            if(ModelState.IsValid)
            {
                _context.produto.Update(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(await _context.produto.FirstOrDefaultAsync(c => c.Id == id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirma(long? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var t = await _context.produto.FirstOrDefaultAsync(d=> d.Id == id);

            if(t == null)
            {
                return RedirectToAction(nameof(Index));
            }

            _context.produto.Remove(t);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
