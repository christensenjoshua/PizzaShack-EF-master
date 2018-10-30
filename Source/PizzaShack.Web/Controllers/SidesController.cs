using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaShack.Business;
using PizzaShack.Data;
using PizzaShack.Entities;

namespace PizzaShack.Web.Controllers
{
    public class SidesController : Controller
    {
        private readonly PizzaService _ps;

        public SidesController(PizzaService ps)
        {
            _ps = ps;
        }

        // GET: Sides
        public IActionResult Index()
        {
            return View(_ps.GetSides());
        }

        //// GET: Sides/Details/5
        public IActionResult Details(int id)
        {
            var side = _ps.GetSideById(id);
            if (side == null)
            {
                return NotFound();
            }

            return View(side);
        }

        //// GET: Sides/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Sides/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Side side)
        {
            if (ModelState.IsValid)
            {
                _ps.CreateSide(side);
                return RedirectToAction(nameof(Index));
            }
            return View(side);
        }

        //// GET: Sides/Edit/5
        public IActionResult Edit(int id)
        {
            var side = _ps.GetSideById(id);
            if (side == null)
            {
                return NotFound();
            }
            return View(side);
        }

        //// POST: Sides/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Side side)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ps.UpdateSide(side);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_ps.SideExists(side.Id))
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
            return View(side);
        }

        //// GET: Sides/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var side = _ps.GetSideById(id);
            if (side == null)
            {
                return NotFound();
            }

            return View(side);
        }

        //// POST: Sides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var side = _ps.GetSideById(id);
            if(side == null)
            {
                return NotFound();
            }
            _ps.RemoveSide(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
