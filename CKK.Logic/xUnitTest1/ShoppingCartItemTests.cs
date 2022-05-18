using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace StructuredProject1.Logic.TestsForStudents
{
    public class ShoppingCartItemTests
    {
        [Fact]
        public void Constructor_SetsProductCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.SetId(2);
                var cartItem = new ShoppingCartItem(testProduct, 1);
                //Act
                var actual = cartItem.GetProduct();
                //Assert
                Assert.Equal(testProduct, actual);
            } catch
            {
                throw new XunitException("You probably don't have the correct constructor or methods.");
            }
            
        } 

        [Fact]
        public void Constructor_SetsQuantityCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.SetId(3);
                var expected = 56;
                var cartItem = new ShoppingCartItem(testProduct, expected);
                //Act
                var actual = cartItem.GetQuantity();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("You probably don't have the correct constructor or right methods.");
                //Assert.False(true, "There was an error that occurred");
            }
        }
        [Fact]
        public void GetSetProduct_ShouldSetAndReturnCorrectProduct()
        {
            try
            {
                //Assemble
                var testProduct = new Product();
                var expected = new Product();
                var cartItem = new ShoppingCartItem(testProduct, 1);
                //Act
                cartItem.SetProduct(expected);
                var actual = cartItem.GetProduct();

                //Assert
                Assert.Equal(expected, actual);
            }catch
            {
                throw new XunitException("The product that was returned was not correct.");
            }
        }

        [Fact]
        public void GetSetQuantity_ShouldSetAndReturnCorrectQuantity()
        {
            try
            {
                //Assemble
                var expected = 13;
                var cartItem = new ShoppingCartItem(new Product(), 2);
                //Act
                cartItem.SetQuantity(expected);
                var actual = cartItem.GetQuantity();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The quantity that was returned was not correct.");
            }
        }
        [Fact]
        public void GetTotal_ShouldReturnTheCorrectTotal()
        {
            try
            {
                //Assemble
                var price = 4.0m;
                var quantity = 2;
                var expected = 8m;
                var testProduct = new Product();
                testProduct.SetPrice(price);

                var cartItem = new ShoppingCartItem(testProduct, quantity);
                //Act
                var actual = cartItem.GetTotal();
                //Assert
                Assert.Equal(expected, actual);
            }catch
            {
                throw new XunitException("The Price that was given was incorrect.");
            }
        }
    }
}
