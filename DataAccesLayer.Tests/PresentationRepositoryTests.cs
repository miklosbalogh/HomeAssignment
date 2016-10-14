using DataAccessLayer;
using DataAccessLayer.Implementation;
using DomainModel;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace DataAccesLayer.Tests
{
    public class PresentationRepositoryTests
    {
        private readonly PresentationRepository _unitUnderTest;
        private readonly Mock<IDataStoreContextFactory<IDataStoreContext>> _dataStoreContextFactory;
        private readonly Mock<IDataStoreContext> _dataStoreContext;

        public PresentationRepositoryTests()
        {
            _dataStoreContext = new Mock<IDataStoreContext>();
            _dataStoreContextFactory = new Mock<IDataStoreContextFactory<IDataStoreContext>>();
            _dataStoreContextFactory.Setup(fact => fact.CreateDataStoreContext()).Returns(_dataStoreContext.Object);

            _unitUnderTest = new PresentationRepository(_dataStoreContextFactory.Object);
        }

        [Fact]
        public async void GetPresentations_WhenPresentationsExistInDataStore_ReturnsThemAll()
        {
            //Arrange
            var presentationsInStore = CreateTestPresentations();
            _dataStoreContext.Setup(store => store.GetPresentations()).ReturnsAsync(presentationsInStore);

            //Act
            var presentations = await _unitUnderTest.GetPresentations();

            //Assert
            presentations.ShouldBeEquivalentTo(presentationsInStore);
        }

        [Fact]
        public async void GetPresentations_WhenMethodReturns_DataStoreContextIsDisposed()
        {
            //Arrange

            //Act
            await _unitUnderTest.GetPresentations();

            //Assert
            _dataStoreContext.Verify(store => store.Dispose());
        }

        private IEnumerable<Presentation> CreateTestPresentations()
        {
            var user = new User { Name = "Test User" };
            return new List<Presentation>
            {
                new Presentation
                {
                    CreatedAt = DateTime.Now,
                    Creator = user,
                    Id = Guid.NewGuid().ToString(),
                    Title = "Nice Prezi"
                },

                new Presentation
                {
                    CreatedAt = DateTime.Now,
                    Creator = user,
                    Id = Guid.NewGuid().ToString(),
                    Title = "Shiny Prezi"
                },

                new Presentation
                {
                    CreatedAt = DateTime.Now,
                    Creator = user,
                    Id = Guid.NewGuid().ToString(),
                    Title = "Hidden Prezi"
                }
            };
        }
    }
}
