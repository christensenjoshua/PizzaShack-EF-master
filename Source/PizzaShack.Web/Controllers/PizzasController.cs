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
    public class PizzasController : Controller
    {
        private readonly PizzaService _ps;

        public PizzasController(PizzaService ps)
        {
            _ps = ps;
        }

        // GET: Pizzas
        public IActionResult Index()
        {
            return View(_ps.GetPizzas());
        }

        // GET: Pizzas/Details/5
        public IActionResult Details(int id)
        {
            var pizza = _ps.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        //// GET: Pizzas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _ps.CreatePizza(pizza);
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        //// GET: Pizzas/Edit/5
        public IActionResult Edit(int id)
        {

            var pizza = _ps.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        //// POST: Pizzas/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ps.UpdatePizza(pizza);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ps.PizzaExists(pizza.Id))
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
            return View(pizza);
        }

        //// GET: Pizzas/Delete/5
        public IActionResult Delete(int id)
        {
            var pizza = _ps.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        //// POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pizza = _ps.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            _ps.RemovePizza(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
