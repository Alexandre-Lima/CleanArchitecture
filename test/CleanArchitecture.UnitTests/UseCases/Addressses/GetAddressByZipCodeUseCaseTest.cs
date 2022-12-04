using CleanArchitecture.Borders.Adapters.Interfaces;
using CleanArchitecture.Borders.Entities;
using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.UnitTests.Builders;
using CleanArchitecture.UseCases.Addressses;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchitecture.UnitTests.UseCases.Addressses;

public class GetAddressByZipCodeUseCaseTest
{

    private readonly Mock<IZipCodeRepository> _zipCodeRepositoryMock;
    private readonly Mock<IAddressResponseAdapter> _adapterMock;
    private readonly GetAddressByZipCodeUseCase _usecase;

    public GetAddressByZipCodeUseCaseTest()
    {
        _zipCodeRepositoryMock = new Mock<IZipCodeRepository>();
        _adapterMock = new Mock<IAddressResponseAdapter>();

        _usecase = new GetAddressByZipCodeUseCase(
            _zipCodeRepositoryMock.Object,
            _adapterMock.Object
            );
    }

    [Fact]
    public async Task Execute_ReturnAddress_success()
    {
        // Arrange
        var request = new ZipCodeBuilder().Build();
        var addressResponse = new AddressBuilder().Build();

        _adapterMock.Setup(lnq => lnq.ToResponse(It.IsAny<Address>()))
            .Returns(addressResponse);

        _zipCodeRepositoryMock
            .Setup(repository => repository.GetAddress(request))
            .ReturnsAsync(It.IsAny<Address>());

        // Act
        var response = await _usecase.Execute(request);

        // Assert
        response.Should().BeEquivalentTo(addressResponse);
    }
}