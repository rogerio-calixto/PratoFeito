﻿namespace Customers.UnitTests.Application.Customers.Queries.GetCustomerOrdersByCustomerId;

public sealed class GetCustomerOrdersByCustomerIdQueryHandlerTest
{
    private GetCustomerOrdersByCustomerIdQueryHandler GetCustomerOrdersByCustomerIdQueryHandler { get; set; }
    private readonly Mock<ICustomerQueries> mockCustomerQueries = new();

    public GetCustomerOrdersByCustomerIdQueryHandlerTest()
    {
        GetCustomerOrdersByCustomerIdQueryHandler = new GetCustomerOrdersByCustomerIdQueryHandler(mockCustomerQueries.Object);
    }

    [Theory]
    [MemberData(nameof(GetCustomerOrdersByCustomerIdQueryData.ValidGetCustomerOrdersByCustomerIdQuery), MemberType = typeof(GetCustomerOrdersByCustomerIdQueryData))]
    public async Task GetCustomerOrdersByCustomerIdQueryHandler_MustReturnAListOfGetCustomerOrdersByCustomerIdQueryModel_WhenCustomerIdHasCustomerOrder(GetCustomerOrdersByCustomerIdQuery getCustomerOrdersByCustomerIdQuery)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomerOrdersByCustomerIdAsync(getCustomerOrdersByCustomerIdQuery.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<GetCustomerOrdersByCustomerIdQueryModel>()
            {
                new GetCustomerOrdersByCustomerIdQueryModel()
            });

        var result = await GetCustomerOrdersByCustomerIdQueryHandler.Handle(getCustomerOrdersByCustomerIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries
            .Verify(x => x.GetCustomerOrdersByCustomerIdAsync(getCustomerOrdersByCustomerIdQuery.CustomerId, It.IsAny<CancellationToken>()), Times.Once);

        Assert.True(result.Any());
    }

    [Theory]
    [MemberData(nameof(GetCustomerOrdersByCustomerIdQueryData.ValidGetCustomerOrdersByCustomerIdQuery), MemberType = typeof(GetCustomerOrdersByCustomerIdQueryData))]
    public async Task GetCustomerOrdersByCustomerIdQueryHandler_MustReturnAEmptyListOfGetCustomerOrdersByCustomerIdQueryModel_WhenCustomerIdHasentCustomerOrder(GetCustomerOrdersByCustomerIdQuery getCustomerOrdersByCustomerIdQuery)
    {
        mockCustomerQueries
            .Setup(x => x.GetCustomerOrdersByCustomerIdAsync(getCustomerOrdersByCustomerIdQuery.CustomerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<GetCustomerOrdersByCustomerIdQueryModel>());

        var result = await GetCustomerOrdersByCustomerIdQueryHandler.Handle(getCustomerOrdersByCustomerIdQuery, It.IsAny<CancellationToken>());

        mockCustomerQueries
            .Verify(x => x.GetCustomerOrdersByCustomerIdAsync(getCustomerOrdersByCustomerIdQuery.CustomerId, It.IsAny<CancellationToken>()), Times.Once);

        Assert.False(result.Any());
    }
}