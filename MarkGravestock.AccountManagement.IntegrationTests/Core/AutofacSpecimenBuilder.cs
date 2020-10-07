using System;
using Autofac;
using AutoFixture.Kernel;

namespace MarkGravestock.AccountManagement.IntegrationTests.Core
{
    internal class AutofacSpecimenBuilder : ISpecimenBuilder
    {
        private readonly IContainer container;

        public AutofacSpecimenBuilder(IContainer container)
        {
            this.container = container;
        }

        public object Create(object request, ISpecimenContext context)
        {
            var t = request as Type;

            if (t == null)
                return new NoSpecimen();

            container.TryResolve(t, out var result);

            return result ?? new NoSpecimen();
        }
    }
}