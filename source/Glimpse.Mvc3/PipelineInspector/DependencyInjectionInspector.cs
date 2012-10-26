﻿using System.Web.Mvc;
using Glimpse.Core.Extensibility;

namespace Glimpse.Mvc.PipelineInspector
{
    public class DependencyInjectionInspector : IPipelineInspector
    {
        public void Setup(IPipelineInspectorContext context)
        {
            var logger = context.Logger;

            var alternateImplementation = new AlternateImplementation.DependencyResolver(context.ProxyFactory);

            var dependencyResolver = DependencyResolver.Current;

            IDependencyResolver newResolver;
            if (alternateImplementation.TryCreate(dependencyResolver, out newResolver))
            {
                DependencyResolver.SetResolver(newResolver);

                logger.Debug(Resources.ExecutionSetupProxiedIDependencyResolver, dependencyResolver.GetType());
            }
        }

        public void Teardown(IPipelineInspectorContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}