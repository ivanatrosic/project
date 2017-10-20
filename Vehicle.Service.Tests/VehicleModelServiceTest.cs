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
using System.ComponentModel;

namespace Vehicle.Service.Tests
{
    public class VehicleModelServiceTest
    {
        private List<IVehicleModel> VehicleModel;

      
        internal List<IVehicleModel> GenerateVehicleModel (int a, string filter)
        {
            VehicleModel = new List<IVehicleModel>();
            for (int i=1; i<=a; i++)
            {
                var item = new VehicleModelDTO
                {
                    Id = new Guid(a, 0, 0, new byte[8]),
                    MakeId = new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d"),
                    Name = "A"+filter,
                    Abrv = ""
                };
                VehicleModel.Add(item);

            }
            return VehicleModel;

        }



        [Fact]
        public async  void GetAsync_with_filter()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetAsync(It.Is<Paging>(s => s.PageNumber==1 && s.PageSize==4), It.Is<Filter>(s => s.FilterTherm=="golf")))
                .ReturnsAsync(GenerateVehicleModel(4, "golf"));

            var service =  new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetAsync(new Paging(1,4), new Filter("golf"));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(4, "golf"));

        }

        [Fact, DisplayName("Get without filter")]
        public async void GetAsync_without_filter()
        {
            //Arrange

            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetAsync(It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4), It.Is<Filter>(s => s.FilterTherm == "")))
                .ReturnsAsync(GenerateVehicleModel(4, ""));

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetAsync(new Paging(1,4), new Filter(""));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(4, ""));

        }

        [Fact]
        public async void GetByMakeAsync_return_list()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetByMakeAsync(It.Is<Guid>(g => g == new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d")), It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4)))
                .ReturnsAsync(GenerateVehicleModel(2, ""));

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetByMakeAsync(new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d"), new Paging(1,4));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(2, ""));

        }

        [Fact]
        public async void GetByMakeAsync_return_empty_list()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.GetByMakeAsync(It.IsAny<Guid>(), It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4)))
                .ReturnsAsync(new List<IVehicleModel> { });

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.GetByMakeAsync(Guid.NewGuid(), new Paging(1, 4));

            //Assert
            result.Should().BeEmpty();

        }

        [Fact]
        public async void DeleteAsync_when_model_is_passed()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.DeleteAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.DeleteAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Fact]
        public async void DeleteAsync_when_Id_is_passed()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.DeleteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.DeleteAsync(Guid.NewGuid());

            //Assert
            result.Should().BeGreaterThan(0);

        }

        [Fact]
        public async void InsertAsync__when_model_is_passed()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.InsertAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.InsertAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().BeGreaterThan(0);

        }
        [Fact]
        public async void UpdateAsync__when_model_is_passed()
        {
            //Arrange
            var mock = new Mock<IVehicleModelRepository>();
            //setup Mock
            mock.Setup(m => m.UpdateAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            var service = new VehicleModelService(mock.Object);

            //Act
            var result = await service.UpdateAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().BeGreaterThan(0);

        }
    }
}
