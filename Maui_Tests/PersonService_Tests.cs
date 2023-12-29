using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using AdressBook_Library.Services;
using Moq;

namespace Maui_Tests
{
    public class PersonService_Tests
    {
        [Fact]
        public void AddPersonToList_ShouldAddAPersonToAList_AndReturnTrue()
        {
            //Arrange

            IPerson person = new Person
            {
                FirstName = "Fredrik",
                LastName = "Bengtsson",
                PhoneNumber = "0709999999",
                Email = "MazeOfTorment@MorbidAngel.com",
                Street = "Somewhere in time 2c",
                ZipCode = "1000000000",
                City = "The Abyss",
                Country = "Antarctia"
            };

            var mockFileService = new Mock<IFileService>();
            IPersonService personService = new PersonService(mockFileService.Object);

            //Act

            bool res = personService.AddPersonToList(person);

            //Assert

            Assert.True(res);
        }
    }
}
