using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ServiceCenterReception.Controllers;
using ServiceCenterReception.Data;
using ServiceCenterReception.DTO;
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
            var obj = new CustomerVehicleServiceDTO();
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

            var resObj = new generalResponseDTO();
            resObj.action = "success";

            var fakeSvc = A.Fake<ICustomerProfileSvc>();
            A.CallTo(() => fakeSvc.addCustomer(obj)).Returns(Task.FromResult(resObj));
            var controller = new CustomerProfileController(fakeSvc);
            // act
            var result = controller.addCustomer(obj).Result;
            // assert
            Assert.Equal("success", result.action);
        }

        [Fact]
        public void getCustomer_shouldReturn_ByMobileNumber()
        {
            // arrange
            var cust = new CustomerProfile();
            cust.customerName = "Test";
            cust.mobileNumber = 8079041795;
            var resObj = new ServiceDTO();
            
            resObj.CustomerProfile = cust;

            var mobNo = 8079041795;
            var fakeSvc = A.Fake<ICustomerProfileSvc>();
            A.CallTo(() => fakeSvc.getCustomerByMobileNo(mobNo)).Returns(Task.FromResult(resObj));

            var controller = new CustomerProfileController(fakeSvc);

            // act
            var result = controller.getCustomerByMobileNo(mobNo).Result;

            // assert
            Assert.Equal("Test", result.CustomerProfile.customerName);
        }
    }
}
