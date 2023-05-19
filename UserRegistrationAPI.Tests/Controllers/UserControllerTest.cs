using Castle.Core.Configuration;
using FluentAssertions;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserRegistrationAPI.Controllers;
using UserRegistrationAPI.Entities.ViewModels;
using UserRegistrationAPI.Service.IService;
using Xunit;

namespace UserRegistrationAPI.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly UserController sut;
        private readonly Mock<IUserService> userService = new Mock<IUserService>();
        private readonly Mock<ILoggerManager> logger = new Mock<ILoggerManager>();

        public UserControllerTest()
        {
            var configuration = new Mock<IConfiguration>();
            sut = new UserController(userService.Object, logger.Object);
        }

        //[Fact]
        //public async void RegisterUser_InValidEmail()
        //{
        //    //Arrange
        //    //Act
        //    UserViewModel _user = new UserViewModel() { FirstName = "Tasaddq", LastName = "Aziz", Email = null, Password = "Asd@1234" };

        //    var result = await sut.RegisterUser(_user);
        //    //Assert
        //    result.GetType().Should().Be(typeof(OkObjectResult));
        //    (result as OkObjectResult).StatusCode.Should().Be(200);

        //}
        [Fact]
        public async void RegisterUser_UserRegistration()
        {
            //Arrange
            //Act
            UserViewModel _user = new UserViewModel() { FirstName = "Tasaddq", LastName = "Aziz", Email = "ali@gmail.com", Password = "Asd@1234" };

            var result = await sut.RegisterUser(_user);
            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            var res = (result as OkObjectResult);
            (result as OkObjectResult).StatusCode.Should().Be(200);
            var msg = (result as OkObjectResult).Value.GetType().GetProperty("message").GetValue((result as OkObjectResult).Value);
            msg.Should().Be("Registration Success!");

        }
    }
}
