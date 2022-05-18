using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace StructuredProject1.Logic.TestsForStudents
{
    public class StoreTests
    {
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Store store = new();
                int expected = 54321;
                //Act
                store.SetId(expected);
                int actual = store.GetId();
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Id Was not given.");
            }
        }

        [Fact]
        public void GetSetName_ShouldSetAndReturnCorrectName()
        {
            try
            {
                //Assemble
                Store store = new();
                var expected = "David Everton";

                //Act
                store.SetName(expected);
                var actual = store.GetName();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The Correct Name was not given.");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddProductToNextSpot_FromEmpty()
        {
            try
            {
                //Assemble
                Store store = new();
                var expected = new Product();
                store.AddStoreItem(expected);
                //Act
                var actual = store.GetStoreItem(1);
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddProductToNextSpot_OneFull()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var expected = new Product();
                store.AddStoreItem(product1);
                store.AddStoreItem(expected);

                //Act
                var actual = store.GetStoreItem(2);
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }

        [Fact]
        public void AddStoreItem_ShouldAddProductToNextSpot_TwoFull()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var product2 = new Product();
                var expected = new Product();
                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(expected);

                //Act
                var actual = store.GetStoreItem(3);
                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The product was not populated correctly.");
            }
        }
        [Fact]
        public void AddStoreProduct_NoSpotsAvailable()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var product2 = new Product();
                var product3 = new Product();
                var expected = new Product();
                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(product3);
                store.AddStoreItem(expected);

                //Act
                var actual = store.GetStoreItem(3);
                //Assert
                Assert.NotEqual(expected, actual);
                Assert.Equal(product3, actual);
            }
            catch
            {
                throw new XunitException("The product was not populated when it was not supposed to.");
            }
        }

        [Fact]
        public void RemoveStoreItem_ShouldRemoveSelectedItem()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var product2 = new Product();
                var product3 = new Product();
                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(product3);

                //Act
                store.RemoveStoreItem(1);

                //Assert
                Assert.Null(store.GetStoreItem(1));
            }catch
            {
                throw new XunitException("The item was not removed correctly");
            }
        }

        [Fact]
        public void RemoveStoreItem_ShouldNotShiftItems()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var product2 = new Product();
                var product3 = new Product();
                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(product3);

                //Act

                store.RemoveStoreItem(2);
                var actual = store.GetStoreItem(2);
                //Assert
                Assert.Null(store.GetStoreItem(2));
                Assert.Equal(product1, store.GetStoreItem(1));
            }catch
            {
                throw new XunitException("The item did not get removed correctly!");
            }
        }

        [Fact]
        public void GetStoreItem_ShouldReturnCorrectItem()
        {
            try
            {
                //Assemble
                Store store = new();
                var product1 = new Product();
                var expected = new Product();

                store.AddStoreItem(product1);
                store.AddStoreItem(product1);
                store.AddStoreItem(expected);

                //Act
                var actual = store.GetStoreItem(3);

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("The correct Item was not returned!");
            }
        }

        [Fact]
        public void GetStoreItem_ShouldReturnNull()
        {
            try
            {
                //Assemble
                Store store = new();
                //Act

                //Assert
                Assert.Null(store.GetStoreItem(1));
            }catch
            {
                throw new XunitException("The correct value was not given! Should have returned null.");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnCorrectItem()
        {
            try
            {
                //Asemble
                Store store = new();
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var expected = new Product();
                expected.SetId(3);

                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(expected);
                //Act
                var actual = store.FindStoreItemById(3);

                //Assert
                Assert.Equal(expected, actual);
            }catch
            {
                throw new XunitException("Did not return the correct item.");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnNullNotFound()
        {
            try
            {
                //Asemble
                Store store = new();
                var product1 = new Product();
                product1.SetId(1);
                var product2 = new Product();
                product2.SetId(2);
                var expected = new Product();
                expected.SetId(3);

                store.AddStoreItem(product1);
                store.AddStoreItem(product2);
                store.AddStoreItem(expected);

                //Act
                var shouldBeNull = store.FindStoreItemById(15);

                //Assert
                Assert.Null(shouldBeNull);

            }
            catch
            {
                throw new XunitException("Method did not return null");
            }
        }

        [Fact]
        public void FindStoreItemById_ShouldReturnFirstIfMultiple()
        {
            try
            {
                //Asemble
                Store store = new();
                var expected = new Product();
                expected.SetId(1);
                var product2 = new Product();
                product2.SetId(1);
                var product3 = new Product();
                product3.SetId(1);

                store.AddStoreItem(expected);
                store.AddStoreItem(product2);
                store.AddStoreItem(product3);

                //Act
                var actual = store.FindStoreItemById(1);

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("Did not return correct Item.");
            }
        }
    }
}
