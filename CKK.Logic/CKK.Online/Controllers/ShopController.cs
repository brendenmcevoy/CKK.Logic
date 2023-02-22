using CKK.DB.Interfaces;
using CKK.Online.Models;
using CKK.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CKK.Online.Controllers
{
    public class ShopController : Controller
    {
        private readonly IUnitOfWork _uow;
        public ShopController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        [Route("/Shop/shoppingCart")]
        public IActionResult Index()
        {
            var model = new ShopModel(_uow);
            _uow.ShoppingCarts.ClearCart(model.Order.ShoppingCartid); //Start with fresh cart

            return View("shoppingCart",model);
        }

        [HttpGet]
        [Route("/Shop/CheckOut")]
        public IActionResult CheckOutCustomer([FromQuery]int orderId)
        {
            var order = _uow.Orders.GetByIdAsync(orderId).Result; //Gets Order

            List<ShoppingCartItem> items = _uow.ShoppingCarts.GetProducts(order.ShoppingCartid); //Gets all items in Cart

            foreach(var i in items) //Update new quantities inside of DB
            {
                _uow.ShoppingCarts.UpdateAsync(i);
            }
            
            var shoppingCartId = order.ShoppingCartid;

            _uow.ShoppingCarts.Ordered(shoppingCartId); //Delete Shopping Cart

            string statusMessage = "Order Placed Successfully";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') }; //Show user statusMessage
            return View("CheckOut",model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity) //Adds items to the shopping cart and updates total on '+' button click
        {
            var order = _uow.Orders.GetByIdAsync(1).Result;
            var test = _uow.ShoppingCarts.AddToCart(order.ShoppingCartid, productId, quantity);

            var total = _uow.ShoppingCarts.GetTotal(order.ShoppingCartid);

            return Ok(total);
        }
    }
}
