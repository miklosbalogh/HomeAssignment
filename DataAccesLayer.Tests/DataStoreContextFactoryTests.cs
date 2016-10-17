using System;
using DataAccessLayer.Implementation;
using FluentAssertions;
using Xunit;

namespace DataAccesLayer.Tests
{

    public class DataStoreContextFactoryTests
    {
        private readonly DataStoreContextFactory _dataStoreContextFactory;

        public DataStoreContextFactoryTests()
        {
            _dataStoreContextFactory = new DataStoreContextFactory();
        }

        [Fact]
        public void CreateDataStoreContext_ShouldUseConnectionString_AndReturnPresentationJsonFileContextObject()
        {
            //Arrange
            var connectionString = "testConnectionString";
            _dataStoreContextFactory.ConnectionString = connectionString;

            //Act
            var context = _dataStoreContextFactory.CreateDataStoreContext();

            //Assert
            context.ConnectionString.ShouldAllBeEquivalentTo(connectionString);
        }

        [Fact]
        public void CreateDataStoreContext_ConnectionStringIsEmpty_ThrowsExcpetion()
        {
            _dataStoreContextFactory.Invoking(fact => fact.CreateDataStoreContext()).ShouldThrow<ArgumentException>();
        }
    }
}
