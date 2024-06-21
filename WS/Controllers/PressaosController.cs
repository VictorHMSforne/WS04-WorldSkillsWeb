using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WS.Context;
using WS.Models;

namespace WS.Controllers
{
    public class PressaosController : Controller
    {
        private readonly AppDbContext _context;

        public PressaosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pressaos
        public async Task<IActionResult> Index()
        {
              return View(await _context.pressao.ToListAsync());
        }

        // GET: Pressaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.pressao == null)
            {
                return NotFound();
            }

            var pressao = await _context.pressao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pressao == null)
            {
                return NotFound();
            }

            return View(pressao);
        }

        // GET: Pressaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pressaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sistole,Diastole,Data,Hora")] Pressao pressao)
        {
            if (ModelState.IsValid)
            {
                string data = DateTime.Now.ToString("dd/MM/yyyy");
                string hora = DateTime.Now.ToString("HH:mm");
                pressao.Data = data;
                pressao.Hora = hora;

                _context.Add(pressao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pressao);
        }

        // GET: Pressaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.pressao == null)
            {
                return NotFound();
            }

            var pressao = await _context.pressao.FindAsync(id);
            if (pressao == null)
            {
                return NotFound();
            }
            return View(pressao);
        }

        // POST: Pressaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sistole,Diastole,Data,Hora")] Pressao pressao)
        {
            if (id != pressao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pressao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PressaoExists(pressao.Id))
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
            return View(pressao);
        }

        // GET: Pressaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.pressao == null)
            {
                return NotFound();
            }

            var pressao = await _context.pressao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pressao == null)
            {
                return NotFound();
            }

            return View(pressao);
        }

        // POST: Pressaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.pressao == null)
            {
                return Problem("Entity set 'AppDbContext.pressao'  is null.");
            }
            var pressao = await _context.pressao.FindAsync(id);
            if (pressao != null)
            {
                _context.pressao.Remove(pressao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PressaoExists(int id)
        {
          return _context.pressao.Any(e => e.Id == id);
        }
        public IActionResult Principal()
        {
            Pressao pressao = new Pressao();
            var avgSistole = _context.pressao
                                .Select(p => p.Sistole) // Seleciona a coluna Sistole
                                .Average(); 
            
            var avgDiastole = _context.pressao
                                .Select(p => p.Diastole) 
                                .Average(); 
            ViewData["AvgSistole"] = avgSistole;
            ViewData["AvgDiastole"] = avgDiastole;



            return View();
        }
    }
}
