using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoDANIEL.Data;
using TrabalhoDANIEL.Models;

namespace TrabalhoDANIEL.Controllers
{
    public class FuncionarioController : Controller
    {

        private readonly Context _context;

        public FuncionarioController(Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.funcianario.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("Nome","CPF","Endereco","Telefone","Data_de_Nasc")]Funcionario funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.funcianario.Add(funcionario);
                    await _context.SaveChangesAsync();
                    return (RedirectToAction(nameof(Index)));
                }
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError(ex.Message, "Error");
            }
            return View(funcionario);
        }
        [HttpGet]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(await _context.funcianario.FirstOrDefaultAsync(c => c.ID == id ));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _context.funcianario.FirstOrDefaultAsync(c => c.ID == id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit([Bind("ID","Nome", "CPF", "Endereco", "Telefone", "Data_de_Nasc")]Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.funcianario.Update(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionario);
        }

        [HttpGet]

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(await _context.funcianario.FirstOrDefaultAsync(c => c.ID == id));
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirma(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dados = await _context.funcianario.FirstOrDefaultAsync(c => c.ID == id);

            if (dados == null)
            {
                return NotFound();
            }
            _context.funcianario.Remove(dados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
