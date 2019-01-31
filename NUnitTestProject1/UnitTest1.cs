using NUnit.Framework;
using Backend_Skietbaan_T2.Controllers;
using Backend_Skietbaan_T2.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autofac.Extras.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tests {
    public class TestUser {

        private IQueryable<User> mockData = new List<User> {
                new User{Id = 1, Username = "Zintle", Surname = "Skosana", Password = "123"},
                new User{Id = 2, Username = "Mandla", Surname = "Masombuka", Password = "456"}
            }.AsQueryable();


        [TestCase(2, "Mandla", "Masombuka", "456")]
        [TestCase(1, "Zintle", "Skosana", "123")]
        public async Task testGetParam(int id, string username, string surname, string password) {


            var mockSet = new Mock<DbSet<User>>();
            mockSet.Setup(m => m.Find(id)).Returns((mockData.Where(x => x.Id == id).First()));

            var mockContext = new Mock<ModelsContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var controller = new UserController(mockContext.Object);
            User user = controller.Get(id);
            Assert.IsNotNull(user);
            Assert.AreEqual(username, user.Username);
            Assert.AreEqual(surname, user.Surname);
            Assert.AreEqual(password, user.Password);

        }

        [Test]
        public void testGetNoParam() {
            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(mockData.GetEnumerator());

            var mockContext = new Mock<ModelsContext>();
            mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            var controller = new UserController(mockContext.Object);
            var users = controller.Get();

            Assert.IsNotEmpty(users);
            Assert.AreEqual(2, users.Count()); 
        }
    }
}