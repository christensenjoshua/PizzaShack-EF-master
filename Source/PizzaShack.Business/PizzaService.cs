using PizzaShack.Data;
using PizzaShack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaShack.Business
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }


        public void CreatePizza(Pizza pizza)
        {
            //do some work business stuff

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }
        public void UpdatePizza(Pizza pizza)
        {
            // update
            if (PizzaExists(pizza.Id))
            {
                // update the pizza
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();
            }           
        }
        public bool PizzaExists(int id)
        {
            return _context.Pizzas.Any(x => x.Id == id);
        }
        public List<Pizza> GetPizzas()
        {
            //NEVER RETURN IQUERYABLE out of BL OR DBSET
            return _context.Pizzas.ToList();
        }

        public Pizza GetPizzaById(int id)
        {
            return _context.Pizzas.FirstOrDefault(x => x.Id == id);
        }
        public void RemovePizza(int id)
        {
            if(PizzaExists(id))
            {
                _context.Pizzas.Remove(GetPizzaById(id));
            }
        }
        public List<Side> GetSides()
        {
            //NEVER RETURN IQUERYABLE out of BL OR DBSET
            return _context.Sides.ToList();
        }

        public Side GetSideById(int id)
        {
            return _context.Sides.FirstOrDefault(x => x.Id == id);
        }

        public void CreateSide(Side side)
        {
            //do some work business stuff

            _context.Sides.Add(side);
            _context.SaveChanges();
        }
        public void UpdateSide(Side side)
        {
            // update
            if (SideExists(side.Id))
            {
                // update the pizza
                _context.Sides.Update(side);
                _context.SaveChanges();
            }
        }
        public void RemoveSide(int id)
        {
            if (SideExists(id))
            {
                _context.Sides.Remove(GetSideById(id));
            }
        }
        public bool SideExists(int id)
        {
            return _context.Sides.Any(x => x.Id == id);
        }
    }
}
