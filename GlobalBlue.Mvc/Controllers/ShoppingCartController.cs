using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalBlue.Data;
using GlobalBlue.Models;

namespace GlobalBlue.Mvc.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartContext _dbContext;
        
        public ShoppingCartController(ShoppingCartContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var request = await _dbContext.ShoppingCart
                .Include(s => s.CartDetails)
                .Include(s => s.CartDetails.Items)
                .Include(s => s.ShippingDetails)
                .Include(s => s.ContactDetails)
                .ToListAsync();

            return Json(request);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShoppingCart request)
        {
            if (request != null)
            {
                _dbContext.Add(request);
                await _dbContext.SaveChangesAsync();
                return Json(request);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ShoppingCart request)
        {
            if (request == null || request.Id == default(int))
            {
                return NotFound();
            }

            try
            {
                _dbContext.Update(request);
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                if (_dbContext.ShoppingCart.Any(s => s.Id == request.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Json(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var request = _dbContext.ShoppingCart.SingleOrDefaultAsync(s => s.Id == id);

            _dbContext.Remove(request);
            await _dbContext.SaveChangesAsync();

            return await Index();
        }

    }
}