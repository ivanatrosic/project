using System;
using Xunit;
using Vehicle.Common;
using Vehicle.Models;
using Vehicle.Repository.Common;
using Moq;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Vehicle.Repository;

namespace Vehicle.Service.Tests
{
    public class VehicleModelServiceTest
    {
        private List<IVehicleModel> VehicleModel;

        public VehicleModelServiceTest ()
        {
            VehicleModel = new List<IVehicleModel>()
            {
                new VehicleModelDTO { Id=Guid.NewGuid(), MakeId=new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d"), Name="Golf2", Abrv="g2"},
                new VehicleModelDTO { Id=Guid.NewGuid(), MakeId=new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d"), Name="Golf3", Abrv="g3"},
                new VehicleModelDTO { Id=Guid.NewGuid(), MakeId=Guid.NewGuid(), Name="Q5", Abrv="a"},
                new VehicleModelDTO { Id=Guid.NewGuid(), MakeId=Guid.NewGuid(), Name="Q7", Abrv="a"},
            };

        }

        [Fact]
        public async  void GetAsync_withfilter()
        {
            //Arrange
            var filter = new Filter( "Golf");
            var paging = new Paging(1, 4);
            var vehiclemodel = new List<IVehicleModel> { VehicleModel.ElementAt(0), VehicleModel.ElementAt(1) };

            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetAsync(paging, filter))
                .ReturnsAsync(vehiclemodel);

            var service =  new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetAsync(paging, filter);

            //Assert
            result.Should().HaveCount(2, "Because there are 2 items that satisfies filter");

        }

        [Fact]
        public async void GetAsync_withoutfilter()
        {
            //Arrange
            var filter = new Filter("");
            var paging = new Paging(1, 4);

            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetAsync(paging, filter))
                .ReturnsAsync(VehicleModel);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetAsync(paging, filter);

            //Assert
            result.Should().HaveCount(4, "Because page size=4");

        }

        [Fact]
        public async void GetByMakeAsync_returnsanlist()
        {
            //Arrange
            var makeId = new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d");
            var paging = new Paging(1, 4);
            var vehiclemodel = new List<IVehicleModel> { VehicleModel.ElementAt(0), VehicleModel.ElementAt(1) };

            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetByMakeAsync(makeId, paging))
                .ReturnsAsync(vehiclemodel);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetByMakeAsync(makeId, paging);

            //Assert
            result.Should().HaveCount(2, "Because there are 2 items with that makeId");

        }

        [Fact]
        public async void GetByMakeAsync_returnsanemptylist()
        {
            //Arrange
            var makeId = Guid.NewGuid();
            var paging = new Paging(1, 4);

            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetByMakeAsync(makeId, paging))
                .ReturnsAsync(new List<IVehicleModel> { });

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetByMakeAsync(makeId, paging);

            //Assert
            result.Should().HaveCount(0, "Because it is an empty list");

        }

        [Fact]
        public async void DeleteAsync_WithVehiclemodelItem()
        {
            //Arrange
            var vehiclemodel = new VehicleModelDTO { };
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.DeleteAsync(vehiclemodel))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.DeleteAsync(vehiclemodel);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Fact]
        public async void DeleteAsync_WithVehiclemodelId()
        {
            //Arrange
            var vehiclemodelId = Guid.NewGuid();
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.DeleteAsync(vehiclemodelId))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.DeleteAsync(vehiclemodelId);

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Fact]
        public async void InsertAsync_WithVehiclemodelItem()
        {
            //Arrange
            var vehiclemodel = new VehicleModelDTO { };
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.InsertAsync(vehiclemodel))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.InsertAsync(vehiclemodel);

            //Assert
            result.Should().BeGreaterThan(0);

        }
        [Fact]
        public async void UpdateAsync_WithVehiclemodelItem()
        {
            //Arrange
            var vehiclemodel = new VehicleModelDTO { };
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.UpdateAsync(vehiclemodel))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.UpdateAsync(vehiclemodel);

            //Assert
            result.Should().BeGreaterThan(0);

        }
    }
}
