using DataAccessLayer;
using DataAccessLayer.Implementation;
using DomainModel;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using DataAccessLayer.Logger;
using Xunit;

namespace DataAccesLayer.Tests
{
    public class PresentationRepositoryTests
    {
        private readonly PresentationRepository _unitUnderTest;
        private readonly Mock<IDataStoreContext> _dataStoreContext;
        private readonly Mock<ILogger> _logger;

        public PresentationRepositoryTests()
        {
            _dataStoreContext = new Mock<IDataStoreContext>();
            var dataStoreContextFactory = new Mock<IDataStoreContextFactory<IDataStoreContext>>();
            dataStoreContextFactory.Setup(fact => fact.CreateDataStoreContext()).Returns(_dataStoreContext.Object);

            _logger = new Mock<ILogger>();

            _unitUnderTest = new PresentationRepository(dataStoreContextFactory.Object, _logger.Object);
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

        [Fact]
        public async void GetPresentations_CatchesException_NeedsToBeLoggedAndReThrown()
        {
            //Arrange
            var exception = new ArgumentException("Message");
            _dataStoreContext.Setup(d => d.GetPresentations()).ThrowsAsync(exception);

            //Act
            try
            {
                await _unitUnderTest.GetPresentations();
            }
            catch (Exception)
            {
                // ignored
            }

            //Assert
            _logger.Verify(l => l.Error("Message"));
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
