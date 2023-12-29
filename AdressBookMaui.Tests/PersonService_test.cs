using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using AdressBook_Library.Services;

namespace AdressBookMaui.Tests
{
    public class PersonService_test
    {

        [Fact]
        public void GetAllPersonsFromList_ShouldReturnAIEnumerableList_IfTheListIsNotNullOrEmpty()
        {
            FileService f = new FileService();
            PersonService p = new PersonService(f);
            IPerson person = new Person
            {
                Email = "MazeOfTorment@MorbidAngel.com"
            };

            p.AddPersonToList(person);

            //Act
            var list = p.GetAllPersonsFromList();

            //Assert
            Assert.IsAssignableFrom<IEnumerable<IPerson>>(list);
            Assert.NotEmpty(list);
            Assert.NotNull(list);
        }

        [Fact]
        public void GetPersonFromList_ShouldReturnAPerson_IfTheEmailAdressExcists()
        {
            //Arrange
            FileService f = new FileService();         
            PersonService p = new PersonService(f);

            IPerson person = new Person
            {
                Email = "MazeOfTorment@MorbidAngel.com"
            };

            //Act
            p.AddPersonToList(person);
            var res = p.GetPersonFromList(person.Email);

            //Assert
            Assert.IsType<Person>(res);
            Assert.NotNull(res);
        }

        [Fact]
        public void GetPersonFromList_ShouldReturnNull_IfTheEmailAdressDoesNotExcist()
        {
            //Arrange
            FileService f = new FileService();
            PersonService p = new PersonService(f);

            //Act
            var res = p.GetPersonFromList("enEmailSomInteFinns@hotmail.com");

            //Assert
            Assert.Null(res);
            Assert.IsNotType<Person>(res);
        }


        [Fact]
        public void AddContactToList_ShouldAddAContactToTheList_AndThenReturnTrue()
        {
            //Arrange
            FileService f = new FileService();
            PersonService p = new PersonService(f);
            bool expected = true;
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

            //Act
            bool res = p.AddPersonToList(person);

            //Assert
            Assert.True(res);
            Assert.Equal(expected,res);
        }

        [Fact]
        public void AddContactToList_ShouldNotAddAContactToTheList_AndThenReturnFalse()
        {
            //Arrange
            FileService f = new FileService();
            PersonService p = new PersonService(f);

            IPerson p1 = new Person
            {
                Email = "hej@hotmail.com"
            };

            IPerson p2 = new Person
            {
                Email = "hej@hotmail.com"
            };

            p.AddPersonToList(p1);

            //Act

            bool res = p.AddPersonToList(p2);

            //Assert
            Assert.False(res);
        }
    }
}
