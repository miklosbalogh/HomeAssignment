using DataAccessLayer.Implementation;
using DomainModel;
using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace DataAccesLayer.Tests
{
    public class PresentationJsonFileContextTests
    {
        private readonly PresentationJsonFileContext _unitUnderTest;
        private const string path = @"../../Misc/prezis.json";

        public PresentationJsonFileContextTests()
        {
            _unitUnderTest = new PresentationJsonFileContext(path);
        }

        [Fact]
        public async void GetPresentations_GetsData_FromPathWasGiven()
        {
            //Arrange
            var testPrezi = new Presentation
            {
                Id = "56f137f432fbb67217182785",
                Title = "incididunt amet ad nostrud",
                ThumbNailUrl = "https://placeimg.com/400/400/any",
                Creator = new User { Name = "consectetur laborum", ProfileUrl = "http://randomprofile.prezi.com/" },
                CreatedAt = new DateTime(2014, 3, 6)
            };

            //Act
            var presentations = await _unitUnderTest.GetPresentations();

            //Assert
            _unitUnderTest.ConnectionString.ShouldBeEquivalentTo(path);
            presentations.Should().HaveCount(100);
            presentations.Any(p => p.Id.Equals(testPrezi.Id) && p.Title.Equals(testPrezi.Title) && p.Creator.Name.Equals(testPrezi.Creator.Name)).Should().BeTrue();
        }
    }
}
