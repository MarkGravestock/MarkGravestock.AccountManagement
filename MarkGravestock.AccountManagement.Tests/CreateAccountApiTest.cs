using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MarkGravestock.AccountManagement.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MarkGravestock.OrderManagement.Tests
{
    // Test List
    // 1. Create across service instances
    public class CreateAccountApiTest
    {
        [Fact]
        public async Task it_can_create_an_account_using_the_api()
        {
            using var factory = new WebApplicationFactory<Startup>();
            
            var client = factory.CreateClient();

            var aCustomerId = Guid.NewGuid();
            
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = aCustomerId})
            };
            
            var responseMessage = await client.SendAsync(postRequest);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdLocation = responseMessage.Headers.Location;

            var result = await client.GetFromJsonAsync<AccountDto>(createdLocation);

            result.CustomerId.Should().Be(aCustomerId);
        }

        [Fact]
        public async Task it_returns_not_found_for_invalid_account_id()
        {
            using var factory = new WebApplicationFactory<Startup>();
            
            var client = factory.CreateClient();

            var responseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get,"/accounts/" + Guid.NewGuid()));

            responseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        private class AccountDto
        {
            public Guid Id { get; set; }
            public Guid CustomerId { get; set; }
        }
    }
}