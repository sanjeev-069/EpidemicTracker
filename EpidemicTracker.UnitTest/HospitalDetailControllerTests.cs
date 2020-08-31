using EpidemicTrackerApplication.Controllers;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EpidemicTracker.UnitTest
{
    public class HospitalDetailControllerTests
    {
        private readonly Mock<IHospitalRepository> _mockRepo;
        private readonly HospitalController _controller;

        public HospitalDetailControllerTests()
        {
            _mockRepo = new Mock<IHospitalRepository>();
            _controller = new HospitalController(_mockRepo.Object);
        }
        [Fact]
        public void GetHospital_ReturnsHospitalObject()
        {
            var result = _controller.GetHospital();
            Assert.IsType<ActionResult<HospitalDTO>>(result);

        }
    }
}
