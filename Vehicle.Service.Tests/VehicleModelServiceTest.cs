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
    public class VehicleModelServiceFixture
    {
        public Mock<IVehicleModelRepository> Repository;
        public VehicleModelService Target;

        public VehicleModelServiceFixture()
        {
            Repository = new Mock<IVehicleModelRepository>();
            Target = new VehicleModelService(Repository.Object);
        }



    }


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


        public VehicleModelServiceFixture fixture;

        public VehicleModelServiceTest()

        {
            fixture = new VehicleModelServiceFixture();
        }


        [Fact]
        public async  void GetAsync_with_filter()
        {
            //Arrange
            fixture.Repository.Setup(m => m.GetAsync(It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4), It.Is<Filter>(s => s.FilterTherm == "golf")))
                .ReturnsAsync(GenerateVehicleModel(4, "golf"));
           

            //Act
            var result = await fixture.Target.GetAsync(new Paging(1,4), new Filter("golf"));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(4, "golf"));

        }

        [Fact, DisplayName("Get without filter")]
        public async void GetAsync_without_filter()
        {
            //Arrange
            
            fixture.Repository.Setup(m => m.GetAsync(It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4), It.Is<Filter>(s => s.FilterTherm == "")))
                .ReturnsAsync(GenerateVehicleModel(4, ""));


            //Act
            var result = await fixture.Target.GetAsync(new Paging(1,4), new Filter(""));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(4, ""));

        }

        [Fact]
        public async void GetByMakeAsync_return_list()
        {
            //Arrange
            fixture.Repository.Setup(m => m.GetByMakeAsync(It.Is<Guid>(g => g == new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d")), It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4)))
                .ReturnsAsync(GenerateVehicleModel(2, ""));


            //Act
            var result = await fixture.Target.GetByMakeAsync(new Guid("fc0f68a9-7976-40c0-b751-1175597aef6d"), new Paging(1,4));

            //Assert
            result.Should().NotBeNull();
            result.ShouldAllBeEquivalentTo(GenerateVehicleModel(2, ""));

        }

        [Fact]
        public async void GetByMakeAsync_return_empty_list()
        {
            //Arrange
            fixture.Repository.Setup(m => m.GetByMakeAsync(It.IsAny<Guid>(), It.Is<Paging>(s => s.PageNumber == 1 && s.PageSize == 4)))
                .ReturnsAsync(new List<IVehicleModel> { });


            //Act
            var result = await fixture.Target.GetByMakeAsync(Guid.NewGuid(), new Paging(1, 4));

            //Assert
            result.Should().BeEmpty();

        }

        [Fact]
        public async void DeleteAsync_when_model_is_passed()
        {
            //Arrange
         
            fixture.Repository.Setup(m => m.DeleteAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            //Act
            var result = await fixture.Target.DeleteAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().Be(1);

        }

        [Fact]
        public async void DeleteAsync_when_Id_is_passed()
        {
            //Arrange
            fixture.Repository.Setup(m => m.DeleteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(1);

            //Act
            var result = await fixture.Target.DeleteAsync(Guid.NewGuid());

            //Assert
            result.Should().Be(1);

        }

        [Fact]
        public async void InsertAsync__when_model_is_passed()
        {
            //Arrange
          
            fixture.Repository.Setup(m => m.InsertAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            //Act
            var result = await fixture.Target.InsertAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().Be(1);

        }
        [Fact]
        public async void UpdateAsync__when_model_is_passed()
        {
            //Arrange
            fixture.Repository.Setup(m => m.UpdateAsync(It.IsAny<VehicleModelDTO>()))
                .ReturnsAsync(1);

            //Act
            var result = await fixture.Target.UpdateAsync(It.IsAny<VehicleModelDTO>());

            //Assert
            result.Should().Be(1);

        }
    }
}
