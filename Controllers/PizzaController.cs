using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers {
    [ApiController]
    [Route("/pizza")]
    public class PizzaController: ControllerBase {
        public PizzaController() {
        }


        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
        
        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id) {
            var pizza = PizzaService.Get(id);

            if(pizza == null)
                return NotFound();

            return pizza;
        }
        
        // Add a new pizza
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {            
            // This code will save the pizza and return a result
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }
        
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            // This code will update the pizza and return a result

            if (id != pizza.Id)
                return BadRequest();
            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);           

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }

    }
}