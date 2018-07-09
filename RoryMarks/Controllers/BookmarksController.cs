﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoryMarks.Models;

namespace RoryMarks.Controllers
{
    public class BookmarksController : Controller
    {
        private readonly RoryMarksContext _context;

        public BookmarksController(RoryMarksContext context)
        {
            _context = context;
        }

        // GET: Bookmarks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookmarks.ToListAsync());
        }

        // GET: Bookmarks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmarks = await _context.Bookmarks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookmarks == null)
            {
                return NotFound();
            }

            return View(bookmarks);
        }

        // GET: Bookmarks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookmarks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Bookmark")] Bookmarks bookmarks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookmarks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookmarks);
        }

        // GET: Bookmarks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmarks = await _context.Bookmarks.FindAsync(id);
            if (bookmarks == null)
            {
                return NotFound();
            }
            return View(bookmarks);
        }

        // POST: Bookmarks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Bookmark")] Bookmarks bookmarks)
        {
            if (id != bookmarks.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookmarks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookmarksExists(bookmarks.ID))
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
            return View(bookmarks);
        }

        // GET: Bookmarks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmarks = await _context.Bookmarks
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bookmarks == null)
            {
                return NotFound();
            }

            return View(bookmarks);
        }

        // POST: Bookmarks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookmarks = await _context.Bookmarks.FindAsync(id);
            _context.Bookmarks.Remove(bookmarks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookmarksExists(int id)
        {
            return _context.Bookmarks.Any(e => e.ID == id);
        }
    }
}
