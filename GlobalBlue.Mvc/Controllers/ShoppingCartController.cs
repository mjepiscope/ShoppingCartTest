using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalBlue.Data;
using GlobalBlue.Models;
using GlobalBlue.Services;
using GlobalBlue.Mvc.Models;

namespace GlobalBlue.Mvc.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartContext _dbContext;
        private readonly IShoppingCartValidator _validator;
        
        public ShoppingCartController(ShoppingCartContext dbContext, IShoppingCartValidator validator)
        {
            _dbContext = dbContext;
            _validator = validator;
        }

        public JsonResult TestConnect()
        {
            return new JsonResult("Connection Successful");
        }

        public async Task<IActionResult> Index()
        {
            var shoppingCarts = await _dbContext.ShoppingCart
                .Include(s => s.CartDetails)
                .Include(s => s.CartDetails.Items)
                .Include(s => s.ShippingDetails)
                .Include(s => s.ShippingDetails.HomeAddress)
                .Include(s => s.ShippingDetails.OfficeAddress)
                .Include(s => s.ContactDetails)
                .ToListAsync();

            var response = new ShoppingCartsResponse();
            response.ShoppingCarts = shoppingCarts;
            response.ErrorMessage = shoppingCarts == null || shoppingCarts.Count == 0
                ? "No records found"
                : string.Empty;

            return Json(response);
        }

        public async Task<IActionResult> GetById(int id)
        {
            var shoppingCart = await _dbContext.ShoppingCart
                .Where(s => s.Id == id)
                .Include(s => s.CartDetails)
                .Include(s => s.CartDetails.Items)
                .Include(s => s.ShippingDetails)
                .Include(s => s.ShippingDetails.HomeAddress)
                .Include(s => s.ShippingDetails.OfficeAddress)
                .Include(s => s.ContactDetails)
                .SingleOrDefaultAsync();

            var response = new ShoppingCartResponse();
            response.ShoppingCart = shoppingCart;
            response.ErrorMessage = shoppingCart == null
                ? "Id not existing"
                : string.Empty;

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShoppingCart request)
        {
            if (request != null && _validator.IsValid(request))
            {
                _dbContext.Add(request);
                await _dbContext.SaveChangesAsync();
                return Json(true);
            }

            return Json(false);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] ShoppingCartUpdateRequest request)
        {
            if (request == null 
                || request.ShoppingCart == null 
                || request.ShoppingCart.Id == default(int))
            {
                return Json(false);
            }

            try
            {
                if(_validator.IsValid(request.ShoppingCart))
                {
                    UpdateCartDetailItems(request.DeletedItems);

                    _dbContext.Update(request.ShoppingCart);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch(DbUpdateConcurrencyException ex)
            {
                if (_dbContext.ShoppingCart.Any(s => s.Id == request.ShoppingCart.Id))
                {
                    return Json(false);;
                }
                else
                {
                    throw;
                }
            }

            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var request = _dbContext.ShoppingCart.SingleOrDefaultAsync(s => s.Id == id);

            _dbContext.Remove(request);
            await _dbContext.SaveChangesAsync();

            return await Index();
        }

        private void UpdateCartDetailItems(List<Item> deletedItems) 
        {
            //var items = _dbContext.Items.Where(i => i.CartDetailsId == cartDetails.Id);

            foreach (var item in deletedItems) 
            {
                _dbContext.Items.Remove(item);
            }
        }
    }
}