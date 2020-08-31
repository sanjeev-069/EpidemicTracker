using EpidemicTrackerApplication.Controllers;
using EpidemicTrackerApplication.Entities;
using EpidemicTrackerApplication.Models;
using EpidemicTrackerApplication.Repositories.Interfaces;
using EpidemicTrackerApplication.Repositories.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Assert = Xunit.Assert;

namespace EpidemicTracker.UnitTest
{
    public class TestHospitalController
    {
        [Fact]
        public void GetHospital()
        {
            // Arrange
            var mockRepository = new Mock<IHospitalRepository>();
            mockRepository.Setup(x => x.GetHospitalId(7))
                .Returns(new List<HospitalDTO>());
                

            var controller = new HospitalController(mockRepository.Object);

            // Act
           var actionResult = controller.GetHospitalbyId(7);
            var contentResult = actionResult as ActionResult<HospitalDTO> ;
                // Assert

            Assert.NotNull(contentResult);
            //Assert.Equal(List<HospitalDTO>,actionResult);
          //  Assert.Equal(2,contentResult)
        }
    }
}
