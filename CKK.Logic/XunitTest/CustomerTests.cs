using CKK.Logic.Models;
using Xunit;
using Xunit.Sdk;

namespace CKK.TestsForStudents
{
    public class CustomerTests
    {        
        [Fact]
        public void GetSetId_ShouldSetAndReturnCorrectId()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                int expected = 54321;
                //Act
                customer.SetId(expected);
                int actual = customer.GetId();
                //Assert
                Assert.Equal(expected, actual);
            }catch
            {
                throw new XunitException("There was an error that occurred");
            }
        }

        [Fact]
        public void GetSetName_ShouldSetAndReturnCorrectName()
        {
            try
            {
                //Assemble
                Customer customer = new Customer();
                var expected = "David Everton";

                //Act
                customer.SetName(expected);
                var actual = customer.GetName();

                //Assert
                Assert.Equal(expected, actual);
            }
            catch
            {
                throw new XunitException("There was an error that occurred");
            }
        }

        [Fact]
        public void GetSetAddress_ShouldSetAndReturnCorrectAddress()
        {
           // try
           // {
                //Assemble
                Customer customer = new Customer();
                var expected = "200 Washington";

                //Act
                customer.SetAddress(expected);
                var actual = customer.GetAddress();

                //Assert
                Assert.Equal(expected, actual);
            //} catch
           // {
              //  throw new X-unit Exception("There was an error that occurred");
           // }
        }
    }
}
