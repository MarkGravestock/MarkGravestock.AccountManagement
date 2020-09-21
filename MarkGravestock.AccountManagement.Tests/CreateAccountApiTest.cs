using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MarkGravestock.OrderManagement.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MarkGravestock.OrderManagement.Tests
{
    public class CreateAccountApiTest
    {
        [Fact]
        public async Task it_can_create_an_account_using_the_api()
        {
            using var factory = new WebApplicationFactory<Startup>();
            
            var client = factory.CreateClient();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = Guid.NewGuid()})
            };
            
            var responseMessage = await client.SendAsync(postRequest);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
        }
    }
}