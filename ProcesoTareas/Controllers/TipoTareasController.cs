﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcesoTareas.Models;

namespace ProcesoTareas.Controllers
{
    public class TipoTareasController : Controller
    {
        private readonly MyDBContext _context;

        public TipoTareasController(MyDBContext context)
        {
            _context = context;
        }

        // GET: TipoTareas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTareas.ToListAsync());
        }

        // GET: TipoTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarea = await _context.TipoTareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTarea == null)
            {
                return NotFound();
            }

            return View(tipoTarea);
        }

        // GET: TipoTareas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,Debaja,FechaAlta,UserId,FechaMod")] TipoTarea tipoTarea)
        {
            if (ModelState.IsValid)
            {
                tipoTarea.FechaAlta = DateTime.Now;
                tipoTarea.FechaMod = DateTime.Now;
                tipoTarea.Debaja = "N";
                tipoTarea.UserId = "";
                _context.Add(tipoTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTarea);
        }

        // GET: TipoTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarea = await _context.TipoTareas.FindAsync(id);
            if (tipoTarea == null)
            {
                return NotFound();
            }
            return View(tipoTarea);
        }

        // POST: TipoTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,Debaja,FechaAlta,UserId,FechaMod")] TipoTarea tipoTarea)
        {
            if (id != tipoTarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tipoTarea.FechaMod = DateTime.Now;
                    _context.Update(tipoTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTareaExists(tipoTarea.Id))
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
            return View(tipoTarea);
        }

        // GET: TipoTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTarea = await _context.TipoTareas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoTarea == null)
            {
                return NotFound();
            }

            return View(tipoTarea);
        }

        // POST: TipoTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTarea = await _context.TipoTareas.FindAsync(id);
            _context.TipoTareas.Remove(tipoTarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DarBaja(int? id)
        {
            var tipoTarea = await _context.TipoTareas.FindAsync(id);
            tipoTarea.FechaMod = DateTime.Now;
            tipoTarea.Debaja = "S";
            _context.TipoTareas.Update(tipoTarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTareaExists(int id)
        {
            return _context.TipoTareas.Any(e => e.Id == id);
        }
    }
}
