using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMailBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMailBox.Controllers
{
  public class MailBoxController : Controller
  {
    private readonly MailBoxContext _context;

    public MailBoxController(MailBoxContext context)
    {
      _context = context;
    }

    // GET: MailBox
    public async Task<IActionResult> Index()
    {
      return View(await _context.MailBoxes.ToListAsync());
    }
    // GET: boites-aux-lettres/{reference}
    public IActionResult DetailsByReference(String reference)
    {
      MailBox mailbox = _context.MailBoxes.FirstOrDefault(mb => mb.Reference == reference);
      if (mailbox == null)
        return NotFound("Mailbox not found");
      return View(viewName: "Details", model: mailbox);
    }
    // GET: MailBox/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mailBox = await _context.MailBoxes
          .SingleOrDefaultAsync(m => m.Id == id);
      if (mailBox == null)
      {
        return NotFound();
      }

      return View(mailBox);
    }

    // GET: MailBox/Create
    public IActionResult Create()
    {
      ProvideColorList();
      return View();
    }

    // POST: MailBox/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Reference,Name,ColorId,Height,Width,Depth,ImagePath")] MailBox mailBox)
    {
      if (ModelState.IsValid)
      {
        _context.Add(mailBox);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      ProvideColorList();
      return View(mailBox);
    }

    // GET: MailBox/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      MailBoxEditViewModel mailBox = await _context.MailBoxes
        .Include(m => m.Color)
        .Select(m => new MailBoxEditViewModel{
          Id = m.Id,
          Color = m.Color,
          Name = m.Name,
          ImagePath = m.ImagePath,
          Reference = m.Reference,
          Height = m.Height,
          Depth = m.Depth,
          Width = m.Width,
          ColorId = m.ColorId
        })
        .SingleOrDefaultAsync(m => m.Id == id);
      if (mailBox == null)
      {
        return NotFound();
      }
      ProvideColorList();
      return View(mailBox);
    }

    // POST: MailBox/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Reference,Name,ColorId,Height,Width,Depth,ImagePath")] MailBox mailBox)
    {
      if (id != mailBox.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(mailBox);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MailBoxExists(mailBox.Id))
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
      ProvideColorList();
      return View(mailBox);
    }

    // GET: MailBox/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var mailBox = await _context.MailBoxes
          .Include(m => m.Color)
          .SingleOrDefaultAsync(m => m.Id == id);
      if (mailBox == null)
      {
        return NotFound();
      }

      return View(mailBox);
    }

    // POST: MailBox/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var mailBox = await _context.MailBoxes.SingleOrDefaultAsync(m => m.Id == id);
      _context.MailBoxes.Remove(mailBox);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool MailBoxExists(int id)
    {
      return _context.MailBoxes.Any(e => e.Id == id);
    }

    private void ProvideColorList()
    {
      List<SelectListItem> colors = _context.Colors
                                            .Select
                                              (
                                                 c => new SelectListItem
                                                 {
                                                   Value = c.Id.ToString(),
                                                   Text = c.Name
                                                 }
                                              )
                                            .ToList();
      ViewBag.Colors = colors;
    }
  }
}
