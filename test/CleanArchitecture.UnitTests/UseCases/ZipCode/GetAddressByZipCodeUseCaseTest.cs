using CleanArchitecture.Borders.Repositories;
using CleanArchitecture.UnitTests.Builders;
using CleanArchitecture.UseCases.ZipCode;
using FluentAssertions;
using Moq;
using Xunit;

namespace CleanArchitecture.UnitTests.UseCases.ZipCode;

public class GetAddressByZipCodeUseCaseTest
{

    private readonly Mock<IZipCodeRepository> _zipCodeRepositoryMock;
    private readonly GetAddressByZipCodeUseCase _usecase;

    public GetAddressByZipCodeUseCaseTest()
    {
        _zipCodeRepositoryMock = new Mock<IZipCodeRepository>();

        _usecase = new GetAddressByZipCodeUseCase(_zipCodeRepositoryMock.Object);
    }


    [Fact]
    public async Task Execute_ReturnAddress_success()
    {
        // Arrange
        var request = new ZipCodeBuilder().Build();
        var addressResponse = new AddressBuilder().Build();

        _zipCodeRepositoryMock
            .Setup(repository => repository.GetAnddress(request))
            .ReturnsAsync(addressResponse);

        // Act
        var response = await _usecase.Execute(request);

        // Assert
        response.Should().BeEquivalentTo(addressResponse);
    }
}