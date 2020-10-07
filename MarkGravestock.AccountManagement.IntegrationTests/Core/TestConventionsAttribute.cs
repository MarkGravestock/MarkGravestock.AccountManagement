using Autofac;
using AutoFixture;
using AutoFixture.Xunit2;
using Mark.Gravestock.AccountManagement.Application.Configuration;
using MarkGravestock.AccountManagement.Infrastructure.Configuration;

namespace MarkGravestock.AccountManagement.IntegrationTests.Core
{
    public class TestConventionsAttribute : AutoDataAttribute
    {
        public TestConventionsAttribute() : base(CreateFixture)
        {
        }
        
        private static Fixture CreateFixture()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule(new InfrastructureModule(Configuration.DevelopmentConnectionString()));
            var container = builder.Build();
            
            var fixture = new Fixture();
            fixture.Customizations.Add(new AutofacSpecimenBuilder(container));
            return fixture;
        }
    }
}