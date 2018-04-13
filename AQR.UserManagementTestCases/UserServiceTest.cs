using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AQR.UserManagement;
using AQR.UserManagement.Controllers;
using AQR.BusinessLayer;
using Moq;
using System.Xml.Linq;
using AQR.Repository;
using DE = AQR.DataEntities;
using DM = AQR.DomainModels;
using System.Web.Mvc;
using System.Collections.Generic;


namespace AQR.UserManagementTestCases
{
    //public class AutoMapperConfiguration
    //{
    //    public static void Configure()
    //    {
    //        Mapper.Initialize(cfg =>
    //        {
    //            cfg.CreateMap<DE.User, DM.User>()
    //                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.UserFirstName))
    //                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.UserLastName));

    //            cfg.CreateMap<DM.User, DE.User>()
    //                .ForMember(dest => dest.UserFirstName, opts => opts.MapFrom(src => src.FirstName))
    //                .ForMember(dest => dest.UserLastName, opts => opts.MapFrom(src => src.LastName));

    //            cfg.CreateMap<DE.Department, DM.Department>()
    //               .ForMember(dest => dest.DepartmentId, opts => opts.MapFrom(src => src.DepartmentID))
    //               .ForMember(dest => dest.DepartmentName, opts => opts.MapFrom(src => src.Name));

    //            cfg.CreateMap<DM.Department, DE.Department>()
    //               .ForMember(dest => dest.DepartmentID, opts => opts.MapFrom(src => src.DepartmentId))
    //               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.DepartmentName));
    //        });
    //    }
    //}

    [TestClass]
    public class UserServiceTest
    {

        [TestMethod]
        public void AddUser()
        {
            bool insertwasCalled = false;
            var user = new DM.User() { FirstName = "John", LastName = "Smith", Gender = "Male", City = "Edision", Password = "Test123", IsDeleted = false };
            var entityuser = new DE.User() { UserFirstName = "John", UserLastName = "Smith", Gender = "Male", City = "Edision", Password = "Test123", IsDeleted = false };

            Mock<IUserRepository> repositoryMock = new Mock<IUserRepository>();
            repositoryMock.Setup(x => x.Add(entityuser)).Callback(() =>
            {
                insertwasCalled = true;
            });

            var userService = new UserService(repositoryMock.Object);

            userService.Add(user);
            Assert.IsFalse(insertwasCalled, "Search was not called.");

            //Assert.AreEqual(true, result);
            // userService.VerifyAll();
            //Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void UserControllerCreateTest()
        {
            bool insertwasCalled = false;
            var user = new DM.User() { FirstName = "", LastName = "Smith", Gender = "Male", City = "Edision", Password = "Test123", IsDeleted = false, Department = new DM.Department() { DepartmentName="test",DepartmentId=1} };
            Mock<IUserService> userServiceMoq = new Mock<IUserService>();
            Mock<IDepartmentService> departmentServiceMoq = new Mock<IDepartmentService>();

            userServiceMoq.Setup(x => x.Add(user)).Callback(() =>
            {
                insertwasCalled = true;
            });

            departmentServiceMoq.Setup(x=>x.GetAllDepartments()).Returns(() => 
                            {
                                return new List<DM.Department>()
                                {
                                    new DM.Department(){DepartmentId=1,DepartmentName ="test"},
                                    new DM.Department(){DepartmentId=2,DepartmentName ="dgfdg"}
                                };
                            });

            UserController controller = new UserController(userServiceMoq.Object,departmentServiceMoq.Object);
            ViewResult result = controller.Create(user) as ViewResult;
            Assert.IsTrue(insertwasCalled, "something wrong");
        }  


    }
    
}
