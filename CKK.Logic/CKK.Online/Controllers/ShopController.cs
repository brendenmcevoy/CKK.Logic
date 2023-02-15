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
            _uow.ShoppingCarts.ClearCart(model.Order.ShoppingCartid);

            return View("shoppingCart",model);
        }

        [HttpGet]
        [Route("/Shop/CheckOut")]
        public IActionResult CheckOutCustomer([FromQuery]int orderId)
        {
            string statusMessage = "";
            var order = _uow.Orders.GetById(orderId);

            List<ShoppingCartItem> items = _uow.ShoppingCarts.GetProducts(order.ShoppingCartid);

            foreach(var i in items)
            {
                var prod = _uow.Products.GetById(i.ProductId);
                _uow.Products.Update(prod);
            }
            
            var shoppingCartId = order.ShoppingCartid;

            _uow.ShoppingCarts.Ordered(shoppingCartId);

            statusMessage = "Order Placed Successfully";

            var model = new CheckOutModel { StatusMessage = statusMessage.Trim('\0') };
            return View("CheckOut",model);
        }

        [HttpGet]
        [Route("Shop/ShoppingCart/Add/{productId}")]
        public IActionResult Add([FromRoute]int productId, [FromQuery]int quantity)
        {
            var order = _uow.Orders.GetById(1);
            var test = _uow.ShoppingCarts.AddToCart(order.ShoppingCartid, productId, quantity);

            var total = _uow.ShoppingCarts.GetTotal(order.ShoppingCartid);

            return Ok(total);
        }
    }
}
