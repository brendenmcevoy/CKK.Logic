using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.TestsForStudents
{
    public class StoreItemTests
    {
        [Fact]
        public void Constructor_SetsProductCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.SetId(1);
                var cartItem = new StoreItem(testProduct, 1);
                //Act
                var actual = cartItem.GetProduct();
                //Assert
                Assert.Equal(testProduct, actual);
            }
            catch
            {
                throw new XunitException("There was an error that occurred. You probably don't have the correct constructor or methods.");
            }
        }

        [Fact]
        public void Constructor_SetsQuantityCorrectly()
        {
            try
            {
                //Assemble
                Product testProduct = new Product();
                testProduct.SetId(2);
                var expected = 24;
                var cartItem = new StoreItem(testProduct, expected);
                //Act
                var actual = cartItem.GetQuantity();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("There was an error that occurred. You probably don't have the correct constructor or right methods.");
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
                var cartItem = new StoreItem(testProduct, 1);
                //Act
                cartItem.SetProduct(expected);
                var actual = cartItem.GetProduct();
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
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
                var cartItem = new StoreItem(new Product(), 2);
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
    }
}
