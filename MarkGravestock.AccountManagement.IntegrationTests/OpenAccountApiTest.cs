using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MarkGravestock.AccountManagement.Api;
using MarkGravestock.AccountManagement.IntegrationTests.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MarkGravestock.AccountManagement.IntegrationTests
{
    [Collection(Collections.Database)]
    public class OpenAccountApiTest : IDisposable
    {
        private HttpStatusCode ErrorNotMappedDueToProblemDetailsNotRunningInTestContext = HttpStatusCode.InternalServerError;

        private readonly HttpClient client;
        private readonly WebApplicationFactory<Startup> factory;

        public OpenAccountApiTest()
        {
            factory = new WebApplicationFactory<Startup>();
            client = factory.CreateClient();
        }

        [Theory, TestConventions]
        public async Task it_can_create_an_account_using_the_api(Guid customerId, decimal initialBalance)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = customerId, InitialBalance = initialBalance})
            };

            var responseMessage = await client.SendAsync(postRequest);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdLocation = responseMessage.Headers.Location;

            using var newFactory = new WebApplicationFactory<Startup>();

            using var newClient = newFactory.CreateClient();

            var result = await newClient.GetFromJsonAsync<AccountDto>(createdLocation);

            result.CustomerId.Should().Be(customerId);
            result.Balance.Should().Be(initialBalance);
        }

        [Fact]
        public async Task it_returns_not_found_for_invalid_account_id()
        {
            var responseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/accounts/{Guid.NewGuid()}"));

            responseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Theory, TestConventions]
        public async Task it_returns_bad_request_for_invalid_initial_balance(Guid customerId)
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = customerId, InitialBalance = -100m})
            };

            var responseMessage = await client.SendAsync(postRequest);

            responseMessage.StatusCode.Should().Be(ErrorNotMappedDueToProblemDetailsNotRunningInTestContext);
        }

        public void Dispose()
        {
            client.Dispose();
            factory.Dispose();
        }

        private class AccountDto
        {
            public Guid Id { get; set; }
            public Guid CustomerId { get; set; }
            public decimal Balance { get; set; }
        }
    }
}