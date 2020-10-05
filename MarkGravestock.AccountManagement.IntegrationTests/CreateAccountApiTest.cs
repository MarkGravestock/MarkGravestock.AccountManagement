using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using MarkGravestock.AccountManagement.Api;
using MarkGravestock.AccountManagement.Infrastructure.Database.Migrations;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace MarkGravestock.AccountManagement.Tests
{
    public class CreateAccountApiTest
    {
        public CreateAccountApiTest()
        {
            const string connectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=AccountManagement; Trusted_connection=true";

            var migrationResult = Migrator.ApplyMigrations(connectionString);

            migrationResult.Error.Should().BeNull();
        }

        [Fact]
        public async Task it_can_create_an_account_using_the_api()
        {
            using var factory = new WebApplicationFactory<Startup>();

            using var client = factory.CreateClient();

            var aCustomerId = Guid.NewGuid();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = aCustomerId})
            };

            var responseMessage = await client.SendAsync(postRequest);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.Created);
            var createdLocation = responseMessage.Headers.Location;

            using var newFactory = new WebApplicationFactory<Startup>();

            using var newClient = newFactory.CreateClient();

            var result = await newClient.GetFromJsonAsync<AccountDto>(createdLocation);

            result.CustomerId.Should().Be(aCustomerId);
        }

        [Fact]
        public async Task it_returns_not_found_for_invalid_account_id()
        {
            using var factory = new WebApplicationFactory<Startup>();

            using var client = factory.CreateClient();

            var responseMessage = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, $"/accounts/{Guid.NewGuid()}"));

            responseMessage.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task it_returns_bad_request_for_invalid_initial_balance()
        {
            using var factory = new WebApplicationFactory<Startup>();

            using var client = factory.CreateClient();

            var aCustomerId = Guid.NewGuid();

            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/accounts")
            {
                Content = JsonContent.Create(new {CustomerId = aCustomerId, InitialBalance = -100m})
            };

            var responseMessage = await client.SendAsync(postRequest);
            
            responseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        private class AccountDto
        {
            public Guid Id { get; set; }
            public Guid CustomerId { get; set; }
        }
    }
}