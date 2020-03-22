using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MicroServerless.Amazon.Lambda
{
    public class LambdaHostBuilder : IHostBuilder
    {
        private readonly HostBuilderContext _hostBuilderContext;
        private readonly IServiceCollection _serviceCollection;

        internal LambdaHostBuilder(IDictionary<object, object> properties = default)
        {
            Properties = properties ?? new Dictionary<object, object>();

            _hostBuilderContext = new HostBuilderContext(Properties);
            _serviceCollection = new ServiceCollection();
        }

        public IDictionary<object, object> Properties { get; }

        public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        {
            configureDelegate(_hostBuilderContext, _serviceCollection);
            return this;
        }

        public IHost Build() => new LambdaHost(_serviceCollection);

        #region unused
        public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate) => throw new NotImplementedException();
        public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate) => throw new NotImplementedException();
        public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate) => throw new NotImplementedException();
        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory) => throw new NotImplementedException();
        public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory) => throw new NotImplementedException();
        #endregion
    }
}