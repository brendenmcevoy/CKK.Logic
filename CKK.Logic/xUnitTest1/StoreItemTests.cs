using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace StructuredProject1.Logic.TestsForStudents
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
                testProduct.SetId(2);
                var expected = 34;
                var cartItem = new StoreItem(testProduct, expected);
                //Act
                var actual = cartItem.GetQuantity();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("You probably don't have the correct constructor or right methods.");
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

        [Fact]
        public void GetTotal_ShouldNotExist()
        {
            try
            {
                //Assemble
                var storeItem = new StoreItem(new Product(), 0);
                var type = storeItem.GetType();
                //Act

                //Assert
                Assert.Null(type.GetMethod("GetTotal"));
            } catch
            {
                throw new XunitException("The method was found. Should not be there.");
            }
        }
    }
}
