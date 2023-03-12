using ServiceCenterReception.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestServiceCenter.ModelBuilder
{
    internal class CustomerProfileModelBuild
    {
        public static CustomerProfile buildCustomerModel()
        {
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

            return obj;
        }
    }
}
