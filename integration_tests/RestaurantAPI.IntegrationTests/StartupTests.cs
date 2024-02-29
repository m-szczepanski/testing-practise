using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RestaurantAPI.IntegrationTests
{
    public class StartupTests : IClassFixture<WebApplicationFactory<Startup>> 
    {
        private List<Type> _controllerTypes;
        private readonly WebApplicationFactory<Startup> _factory;
        public StartupTests(WebApplicationFactory<Startup> factory) 
        {
            _controllerTypes = typeof(Startup)
                .Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ControllerBase))).ToList();

            _factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(service =>
                {
                    _controllerTypes.ForEach(c => service.AddScoped(c));
                });
            });
        }

        [Fact]
        public void ConfigureServices_ForControllers_RegisterAllDependencies()
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();

            // var controller = scope.ServiceProvider.GetService<AccountControllerTests>();
            _controllerTypes.ForEach(t =>
            {
                var controller = scope.ServiceProvider.GetService(t);

                controller.Should().NotBeNull();
            });
        }
    }
}
