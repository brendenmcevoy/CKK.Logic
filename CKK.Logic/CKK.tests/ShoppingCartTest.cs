using System;
using Xunit;
using CKK.Logic.Models;

namespace CKK.tests
{
    public class ShoppingCartTest
    {
        Customer testCustomer = new Customer();
        Store testStore = new Store();


        Product prod1 = new Product();
        Product prod2 = new Product();
        Product prod3 = new Product();
        

        
        [Fact]
        public void AddProduct()

        {
            ShoppingCart testCart = new ShoppingCart(testCustomer);
           
            ShoppingCartItem actual = testCart.AddProduct(prod1,5);
            ShoppingCartItem expected = testCart.GetProductById(1);
            
            Assert.Equal(expected, actual);

            ShoppingCartItem actual2 = testCart.AddProduct(prod2, 5);
            ShoppingCartItem expected2 = testCart.GetProductById(2);

            Assert.Equal(expected2, actual2);

            ShoppingCartItem actual3 = testCart.AddProduct(prod3, 5);
            ShoppingCartItem expected3 = testCart.GetProductById(3);

            Assert.Equal(expected3, actual3);

            ShoppingCartItem actual4 = testCart.AddProduct(prod1, 5);
            ShoppingCartItem expected4 = testCart.GetProductById(1);

            Assert.Equal(expected4, actual4);

            ShoppingCartItem actual5 = testCart.AddProduct(prod2, 5);
            ShoppingCartItem expected5 = testCart.GetProductById(2);

            Assert.Equal(expected5, actual5);

        }
      
        

        [Fact]
        public void RemoveProduct()
        {
            ShoppingCart testCart = new ShoppingCart(testCustomer);

            testCart.AddProduct(prod1, 10);
            testCart.AddProduct(prod2, 10);
            testCart.AddProduct(prod3, 10);
            testCart.AddProduct(prod1, 10);
            testCart.AddProduct(prod2, 10);
            testCart.AddProduct(prod3, 10);

            ShoppingCartItem actual = testCart.RemoveProduct(prod1, 5);
            ShoppingCartItem expected = testCart.GetProductById(1);
            Assert.Equal(expected, actual);

            ShoppingCartItem actual2 = testCart.RemoveProduct(prod1, 5);
            ShoppingCartItem expected2 = testCart.GetProductById(1);
            Assert.Equal(expected2, actual2);

            ShoppingCartItem actual3 = testCart.RemoveProduct(prod1, 5);
            ShoppingCartItem expected3 = testCart.GetProductById(1);
            Assert.Equal(expected3, actual3);
        }
                    
        [Fact]
        public void PassingGetTotal()
        {
            prod1.SetPrice(10);
            prod2.SetPrice(10);
            prod3.SetPrice(10);

            ShoppingCart testCart = new ShoppingCart(testCustomer);

            testCart.AddProduct(prod1, 10);
            testCart.AddProduct(prod2, 10);
            testCart.AddProduct(prod3, 10);

            decimal actual = testCart.GetTotal();
            decimal expected = 300;

            Assert.Equal(expected, actual);


        }
    }
}
