using System.Collections.Generic;
using AutoFixture;
using Lawrence.Tsuro.TechTest.Repository.Contracts;
using Lawrence.Tsuro.TechTest.Services.Contracts;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;
using Lawrence.Tsuro.TechTest.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Lawrence.Tsuro.TechTest.ServicesTest
{
    [ TestClass ]
    public class AddressServiceUnitTest
    {
        [ TestMethod ]
        public void UploadAddressesToDb_Should_Populate_Db_Successfully()
        {
            // arrange
            var fixture = new Fixture();

            var mockAddressRepo    = new Mock<IAddressBookRepository>();
            var mockAddressService = new Mock<IAddressService>();
            var testData           = fixture.Create<List<CsvAddressesReaderDtoDto>>();
            var target             = new AddressService(mockAddressRepo.Object);
            mockAddressService.Setup(x => x.UploadAddressesToDb(testData));

            // act
            mockAddressService.Object.UploadAddressesToDb(testData);

            // assert
            mockAddressService.Verify(x => x.UploadAddressesToDb(testData), Times.Once());
        }

        // todo create unit test
        [ TestMethod ]
        public void UploadAddressesToDb_Should_Populate_Db_UnSuccessfully() { }
    }
}