using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using crud_csharp.Controller;
using crud_csharp.ViewObject;
using Moq;
using crud_csharp.DAO;
using crud_csharp.Model;
using crud_csharp.enums;
using crud_csharp.exceptions;

namespace crud_csharpTest.Tests
{
    [TestClass]
    public class CreateEndpointTest
    {
        [TestMethod]
        public void CreateEndpointWithValidInput()
        {
            Endpoint endpoint = new Endpoint()
            {
                serialNumber = "1",
                meterModelId = 16,
                meterNumber = 1,
                meterFirmwareVersion = "1",
                switchState = 0
            };
            Mock<IBaseDao<Endpoint>> mock = new Mock<IBaseDao<Endpoint>>();
            mock.Setup(dao => dao.Create(endpoint)).Returns(endpoint);
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO()
            {
                serialNumber = "1",
                meterModelId = "nsx1p2w",
                meterNumber = "1",
                switchState = "Disconnected",
                meterFirmwareVersion = "1",
            };
            var resultExpect = mock.Object.Create(endpoint);
            var result = endpointController.Create(endpointVo);
            Assert.AreEqual(resultExpect, result);
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void CreateEndpointWithDuplicatedSerialNumber()
        {
            Endpoint endpoint = new Endpoint()
            {
                serialNumber = "1",
                meterModelId = 16,
                meterNumber = 1,
                meterFirmwareVersion = "1",
                switchState = 0
            };
            Mock<IBaseDao<Endpoint>> mock = new Mock<IBaseDao<Endpoint>>();
            mock.Setup(dao => dao.FindOne(endpoint.serialNumber)).Returns(endpoint);
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO()
            {
                serialNumber = "1",
                meterModelId = "nsx1p2w",
                meterNumber = "1",
                switchState = "Disconnected",
                meterFirmwareVersion = "1",
            };
            var result = endpointController.Create(endpointVo);
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void CreateEndpointWithInvalidMeterModelId()
        {
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO()
            {
                serialNumber = "1",
                meterModelId = "5",
                meterNumber = "1",
                switchState = "Disconnected",
                meterFirmwareVersion = "1",
            };
            var result = endpointController.Create(endpointVo);
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void CreateEndpointWithInvalidSwitchState()
        {
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO()
            {
                serialNumber = "1",
                meterModelId = "nsx1p2w",
                meterNumber = "1",
                switchState = "5",
                meterFirmwareVersion = "1",
            };
            var result = endpointController.Create(endpointVo);
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void CreateEndpointWithEmptySerialNumber()
        {
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO()
            {
                meterModelId = "nsx1p2w",
                meterNumber = "1",
                switchState = "Disconnected",
                meterFirmwareVersion = "1",
            };
            var result = endpointController.Create(endpointVo);
        }

        [TestMethod]
        [ExpectedException(typeof(AppException))]
        public void CreateEndpointWithEmptyEndpoint()
        {
            EndpointController endpointController = new EndpointController();
            EndpointVO endpointVo = new EndpointVO();
            var result = endpointController.Create(endpointVo);
        }
    }
}
