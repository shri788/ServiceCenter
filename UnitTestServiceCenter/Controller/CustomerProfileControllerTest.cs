using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceCenterReception.Controllers;
using ServiceCenterReception.Data;
using ServiceCenterReception.Entity;
using ServiceCenterReception.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnitTestServiceCenter.ModelBuilder;

namespace UnitTestServiceCenter.Controller
{
    public class CustomerProfileControllerTest
    {
        [Fact]
        public void addCustomer_shouldCheckCustomerName_newlyAdded()
        {
            // arrange
            //var obj = CustomerProfileModelBuild.buildCustomerModel();
            var obj = new CustomerProfile();
            obj.customerId = 0;
            obj.mobileNumber = 2222222222;
            obj.customerName = "Test";
            obj.address = "test address";
            obj.addressPinCode = 123456;
            obj.gender = "M";
            obj.email = "UnitTestServiceCenter@er.com";
            obj.DOB = new DateTime(1970, 1, 1);
            obj.DOM = new DateTime(1970, 1, 1);
            obj.lastServiceDate = new DateTime(2023, 10, 10);
            obj.dueInMonths = 5;

            //var fakeSvc = A.Fake<ICustomerProfileSvc>();
            //A.CallTo(() => fakeSvc.addCustomer(obj)).Returns(Task.FromResult(obj));
            //var controller = new CustomerProfileController(fakeSvc);
            //// act
            //var result = controller.addCustomer(obj).Result;
            //// assert
            //Assert.Equal("Test", result.customerName);
        }
    }
}
